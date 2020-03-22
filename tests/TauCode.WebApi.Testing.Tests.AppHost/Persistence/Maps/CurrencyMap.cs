using FluentNHibernate.Mapping;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;

namespace TauCode.WebApi.Testing.Tests.AppHost.Persistence.Maps
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Code);
            this.Map(x => x.Name);
        }
    }
}
