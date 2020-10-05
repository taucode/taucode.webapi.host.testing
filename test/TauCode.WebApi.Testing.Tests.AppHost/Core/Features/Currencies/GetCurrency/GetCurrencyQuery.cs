using TauCode.Cqrs.Queries;
using TauCode.Cqrs.Validation;
using TauCode.Domain.Identities;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.GetCurrency
{
    public class GetCurrencyQuery : Query<GetCurrencyQueryResult>, ICodedEntityQuery
    {
        public CurrencyId Id { get; set; }
        public string Code { get; set; }

        IdBase ICodedEntityQuery.GetId() => Id;
        string ICodedEntityQuery.GetCode() => Code;
        string ICodedEntityQuery.GetIdPropertyName() => nameof(Id);
        string ICodedEntityQuery.GetCodePropertyName() => nameof(Code);
    }
}
