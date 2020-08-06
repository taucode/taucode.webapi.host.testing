using FluentNHibernate.Mapping;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids;

namespace TauCode.WebApi.Testing.Tests.AppHost.Persistence.Maps
{
    public class BidMap : ClassMap<Bid>
    {
        public BidMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Name);
            this.Map(x => x.Price);
        }
    }
}
