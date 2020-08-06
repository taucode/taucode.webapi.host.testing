using TauCode.Mq.Abstractions;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids;
using TauCode.WebApi.Testing.Tests.Client.Messages;

namespace TauCode.WebApi.Testing.Tests.AppHost.AppHandlers
{
    public class BidMessageHandler : MessageHandlerBase<BidMessage>
    {
        private readonly IBidRepository _bidRepository;

        public BidMessageHandler(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public override void Handle(BidMessage message)
        {
            var bid = new Bid(message.Name, message.Price);
            _bidRepository.Save(bid);
        }
    }
}
