using TauCode.Cqrs.Validation;
using TauCode.Validation;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.GetCurrency
{
    public class GetCurrencyQueryValidator : CodedEntityValidator<GetCurrencyQuery, CurrencyCodeValidator>
    {
    }
}
