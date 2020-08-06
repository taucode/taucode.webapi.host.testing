using NHibernate;
using System;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids;

namespace TauCode.WebApi.Testing.Tests.AppHost.Persistence.Repositories
{
    public class NHibernateBidRepository : IBidRepository
    {
        private readonly ISession _session;

        public NHibernateBidRepository(ISession session)
        {
            _session = session;
        }

        public void Save(Bid bid)
        {
            if (bid == null)
            {
                throw new ArgumentNullException(nameof(bid));
            }
            _session.SaveOrUpdate(bid);

        }
    }
}
