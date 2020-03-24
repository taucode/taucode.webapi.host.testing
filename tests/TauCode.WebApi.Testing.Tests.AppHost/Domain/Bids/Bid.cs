using System;

namespace TauCode.WebApi.Testing.Tests.AppHost.Domain.Bids
{
    public class Bid
    {
        private Bid()
        {   
        }

        public Bid(string name, decimal price)
        {
            this.Id = new BidId();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Price = price;
        }

        public BidId Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
