using System;
using System.Threading;
using System.Threading.Tasks;
using TauCode.Cqrs.Mq;
using TauCode.Domain.Events;
using TauCode.Mq;
using TauCode.WebApi.Testing.Tests.AppHost.Core.Exceptions;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies.DomainEvents;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.CreateCurrency
{
    public class CreateCurrencyCommandHandler : DomainEventAwareCommandHandler<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CreateCurrencyCommandHandler(
            ICurrencyRepository currencyRepository,
            IMessagePublisher messagePublisher,
            IDomainEventConverter domainEventConverter)
            : base(messagePublisher, domainEventConverter)
        {
            _currencyRepository = currencyRepository;
        }

        protected override void ExecuteImpl(CreateCurrencyCommand command)
        {
            var existingCurrency = _currencyRepository.GetByCode(command.Code);
            if (existingCurrency != null)
            {
                throw new CodeAlreadyExistsException();
            }

            var currency = new Currency(command.Code, command.Name);
            _currencyRepository.Save(currency);
            command.SetResult(currency.Id);

            DomainEventPublisher.Current.Publish(
                new CurrencyCreatedDomainEvent(
                    currency.Id,
                    currency.Code,
                    currency.Name,
                    (new Guid()).ToString(),
                    DateTime.UtcNow));
        }

        protected override Task ExecuteAsyncImpl(
            CreateCurrencyCommand command,
            CancellationToken cancellationToken = default)
        {
            this.ExecuteImpl(command);
            return Task.CompletedTask;
        }
    }
}
