using System.Collections.Generic;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Bids.GetAllBids
{
    public class GetAllBidsQueryResult
    {
        public IList<BidDto> Items { get; set; }
        public class BidDto
        {
            public BidId Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
