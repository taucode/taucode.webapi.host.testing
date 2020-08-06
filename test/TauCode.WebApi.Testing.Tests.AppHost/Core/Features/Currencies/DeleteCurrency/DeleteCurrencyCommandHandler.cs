using System.Threading;
using System.Threading.Tasks;
using TauCode.Cqrs.Commands;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies.Exceptions;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.DeleteCurrency
{
    public class DeleteCurrencyCommandHandler : ICommandHandler<DeleteCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public DeleteCurrencyCommandHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public void Execute(DeleteCurrencyCommand command)
        {
            var deleted = _currencyRepository.Delete(command.Id);
            if (!deleted)
            {
                throw new CurrencyNotFoundException();
            }
        }

        public Task ExecuteAsync(DeleteCurrencyCommand command, CancellationToken cancellationToken = default)
        {
            this.Execute(command);
            return Task.CompletedTask;
        }
    }
}
