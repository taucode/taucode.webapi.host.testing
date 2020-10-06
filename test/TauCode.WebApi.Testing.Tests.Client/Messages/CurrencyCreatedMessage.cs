using System;
using TauCode.Mq.Abstractions;

namespace TauCode.WebApi.Testing.Tests.Client.Messages
{
    public class CurrencyCreatedMessage : IMessage
    {
        public CurrencyCreatedMessage()
        {   
        }

        public CurrencyCreatedMessage(
            IdDto id,
            string code,
            string name,
            string correlationId,
            DateTimeOffset createdAt)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Code = code ?? throw new ArgumentNullException(nameof(code));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.CorrelationId = correlationId;
            this.CreatedAt = createdAt;
        }

        public IdDto Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Topic { get; set; }
        public string CorrelationId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
