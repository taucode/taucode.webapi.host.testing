using System;
using TauCode.Domain.Identities;

namespace TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids
{
    [Serializable]
    public class BidId : IdBase
    {
        public BidId()
        {
        }

        public BidId(Guid id)
            : base(id)
        {
        }

        public BidId(string id)
            : base(id)
        {
        }
    }
}
