using System.Collections.Generic;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.GetAllCurrencies
{
    public class GetAllCurrenciesQueryResult
    {
        public IList<CurrencyDto> Items { get; set; }
        public class CurrencyDto
        {
            public CurrencyId Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
}
