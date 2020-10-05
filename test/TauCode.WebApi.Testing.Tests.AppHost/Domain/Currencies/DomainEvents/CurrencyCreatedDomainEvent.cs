using System;
using TauCode.Domain.Events;

namespace TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies.DomainEvents
{
    public class CurrencyCreatedDomainEvent : IDomainEvent
    {
        public CurrencyCreatedDomainEvent(
            CurrencyId id,
            string code,
            string name,
            string correlationId,
            DateTimeOffset occurredAt)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Code = code ?? throw new ArgumentNullException(nameof(code));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.CorrelationId = correlationId;
            this.OccurredAt = occurredAt;
        }

        public CurrencyId Id { get; }
        public string Code { get; }
        public string Name { get; }
        public string CorrelationId { get; }
        public DateTimeOffset OccurredAt { get; }
    }
}
