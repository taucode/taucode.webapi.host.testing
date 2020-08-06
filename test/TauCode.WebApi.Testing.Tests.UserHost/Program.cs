using TauCode.Mq.EasyNetQ.Cli;
using TauCode.WebApi.Testing.Tests.Client.Messages;
using TauCode.WebApi.Testing.Tests.UserHost.Handlers;

namespace TauCode.WebApi.Testing.Tests.UserHost
{
    internal class Program : MqProgramBase
    {
        public Program()
            : base(
                new[]
                {
                    typeof(BidMessage),
                },
                new[]
                {
                    typeof(CurrencyCreatedMessageHandler),
                },
                "host=localhost")
        {
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Init();
            program.Run();
        }
    }
}