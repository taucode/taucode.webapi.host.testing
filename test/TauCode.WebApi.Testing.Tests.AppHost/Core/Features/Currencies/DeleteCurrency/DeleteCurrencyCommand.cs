using TauCode.Cqrs.Abstractions;
using TauCode.WebApi.Testing.Tests.AppHost.Domain.Currencies;

namespace TauCode.WebApi.Testing.Tests.AppHost.Core.Features.Currencies.DeleteCurrency
{
    public class DeleteCurrencyCommand : ICommand
    {
        public CurrencyId Id { get; set; }
    }
}
