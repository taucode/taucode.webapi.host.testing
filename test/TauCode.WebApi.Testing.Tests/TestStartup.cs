using Microsoft.Extensions.Configuration;
using TauCode.WebApi.Testing.Tests.AppHost;

namespace TauCode.WebApi.Testing.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        // todo: plug in powerful 'taucode.mq.testing' here!
        //protected override void ConfigureMessaging(ContainerBuilder containerBuilder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
