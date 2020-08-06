using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using TauCode.WebApi.Testing.Tests.AppHost;

namespace TauCode.WebApi.Testing.Tests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void ConfigureMessaging(ContainerBuilder containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
