using Newtonsoft.Json;
using System;
using TauCode.Mq.Abstractions;
using TauCode.WebApi.Testing.Tests.Client.Messages;

namespace TauCode.WebApi.Testing.Tests.UserHost.Handlers
{
    public class CurrencyCreatedMessageHandler : MessageHandlerBase<CurrencyCreatedMessage>
    {
        public override void Handle(CurrencyCreatedMessage message)
        {
            var json = JsonConvert.SerializeObject(message, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
