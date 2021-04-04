using System;
using TauCode.Cqrs.Mq;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies.DomainEvents;
using TauCode.WebApi.Testing.Tests.Client.Messages;

namespace TauCode.WebApi.Testing.Tests.AppHost.AppDomainEventConverters.NestedConverters
{
    public class CurrencyCreatedDomainEventConverter : DomainEventConverterBase<CurrencyCreatedDomainEvent, CurrencyCreatedMessage>
    {
        protected override CurrencyCreatedMessage ConvertImpl(CurrencyCreatedDomainEvent currencyCreatedDomainEvent)
        {
            throw new NotImplementedException();
            //return new CurrencyCreatedMessage(
            //    currencyCreatedDomainEvent.Id.ToIdDto(),
            //    currencyCreatedDomainEvent.Code,
            //    currencyCreatedDomainEvent.Name,
            //    currencyCreatedDomainEvent.CorrelationId,
            //    currencyCreatedDomainEvent.OccurredAt);
        }
    }
}
