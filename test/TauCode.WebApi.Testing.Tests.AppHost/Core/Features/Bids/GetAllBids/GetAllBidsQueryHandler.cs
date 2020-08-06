using NHibernate;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TauCode.Cqrs.Queries;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Bids.GetAllBids
{
    public class GetAllBidsQueryHandler : IQueryHandler<GetAllBidsQuery>
    {
        private readonly ISession _session;

        public GetAllBidsQueryHandler(ISession session)
        {
            _session = session;
        }

        public void Execute(GetAllBidsQuery query)
        {
            var currencies = _session
                .Query<Bid>()
                .OrderBy(x => x.Name)
                .ToList();

            var queryResult = new GetAllBidsQueryResult
            {
                Items = currencies
                    .Select(x => new GetAllBidsQueryResult.BidDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                    })
                    .ToList(),
            };
            query.SetResult(queryResult);
        }

        public Task ExecuteAsync(GetAllBidsQuery query, CancellationToken cancellationToken = default)
        {
            this.Execute(query);
            return Task.CompletedTask;
        }
    }
}
