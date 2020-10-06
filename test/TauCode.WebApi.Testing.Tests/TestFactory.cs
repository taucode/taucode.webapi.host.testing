using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Net.Http;
using TauCode.WebApi.Testing.Tests.AppHost;

namespace TauCode.WebApi.Testing.Tests
{
    public class TestFactory : WebApplicationFactory<TestStartup>, ITestFactory
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TestStartup>();
                    webBuilder.UseSetting(WebHostDefaults.ApplicationKey, typeof(Startup).Assembly.GetName().Name);
                });

        HttpClient ITestFactory.CreateClient()
        {
            var httpClient = this
                .WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot(@"test\TauCode.WebApi.Testing.Tests"))
                .CreateClient();

            return httpClient;
        }

        public TService GetService<TService>()
        {
            var testServer = this.Factories.Single().Server;
            var service = testServer.Services.GetService<TService>();
            return service;
        }
    }
}
