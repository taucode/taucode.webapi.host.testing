using Newtonsoft.Json;
using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TauCode.WebApi.Client.Exceptions;

namespace TauCode.WebApi.Testing
{
    public static class TestingWebApiExtensions
    {
        public static string BuildQueryString(this IDictionary<string, string> parameterDictionary)
        {
            var sb = new StringBuilder();
            var added = false;

            foreach (var pair in parameterDictionary)
            {
                if (pair.Value == null)
                {
                    continue;
                }

                if (added)
                {
                    sb.Append("&");
                }

                added = true;

                sb.Append($"{pair.Key}={pair.Value}");
            }

            return sb.ToString();
        }

        public static string AddQueryParams(string url, IDictionary<string, string> queryParams)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (queryParams == null)
            {
                throw new ArgumentNullException(nameof(queryParams));
            }

            if (queryParams.Count == 0)
            {
                return url; // nothing to add.
            }

            var queryString = queryParams.BuildQueryString();
            var sb = new StringBuilder(url);
            if (!url.Contains("?"))
            {
                sb.Append("?");
            }
            else
            {
                sb.Append("&");
            }

            sb.Append(queryString);
            return sb.ToString();
        }

        public static T ReadAs<T>(this HttpResponseMessage message)
        {
            var json = message.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public static async Task<T> ReadAsAsync<T>(
            this HttpResponseMessage message,
            CancellationToken cancellationToken = default)
        {
            var json = await message.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public static ErrorDto ReadAsError(this HttpResponseMessage message)
        {
            return message.ReadAs<ErrorDto>();
        }

        public static async Task<ErrorDto> ReadAsErrorAsync(
            this HttpResponseMessage message,
            CancellationToken cancellationToken = default)
        {
            return await message.ReadAsAsync<ErrorDto>(cancellationToken);
        }

        public static ValidationErrorDto ReadAsValidationError(this HttpResponseMessage message)
        {
            return message.ReadAs<ValidationErrorDto>();
        }

        public static async Task<ValidationErrorDto> ReadAsValidationErrorAsync(
            this HttpResponseMessage message,
            CancellationToken cancellationToken = default)
        {
            return await message.ReadAsAsync<ValidationErrorDto>(cancellationToken);
        }

        public static void DoInTransaction(this ISession session, Action action)
        {
            using var tran = session.BeginTransaction();
            action();
            tran.Commit();
        }

        public static async Task DoInTransactionAsync(
            this ISession session,
            Func<Task> action,
            CancellationToken cancellationToken = default)
        {
            using var transaction = session.BeginTransaction();

            await action();

            await transaction.CommitAsync(cancellationToken);
        }

        public static ValidationErrorServiceClientException ShouldHaveFailureNumber(
            this ValidationErrorServiceClientException ex,
            int expectedFailureNumber)
        {
            Assert.That(ex.Failures, Has.Count.EqualTo(expectedFailureNumber));
            return ex;
        }

        public static ValidationErrorServiceClientException ShouldContainFailure(
            this ValidationErrorServiceClientException ex,
            string expectedKey,
            string expectedCode,
            string expectedMessage)
        {
            Assert.That(ex.Failures, Does.ContainKey(expectedKey));
            var failure = ex.Failures[expectedKey];
            Assert.That(failure.Code, Is.EqualTo(expectedCode));
            Assert.That(failure.Message, Is.EqualTo(expectedMessage));

            return ex;
        }

        public static ValidationErrorDto ShouldHaveFailureNumber(
            this ValidationErrorDto validationError,
            int expectedFailureNumber)
        {
            Assert.That(validationError.Failures, Has.Count.EqualTo(expectedFailureNumber));
            return validationError;
        }

        public static ValidationErrorDto ShouldContainFailure(
            this ValidationErrorDto validationError,
            string expectedKey,
            string expectedCode,
            string expectedMessage)
        {
            Assert.That(validationError.Failures, Does.ContainKey(expectedKey));
            var failure = validationError.Failures[expectedKey];
            Assert.That(failure.Code, Is.EqualTo(expectedCode));
            Assert.That(failure.Message, Is.EqualTo(expectedMessage));

            return validationError;
        }
    }
}
