using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Globalization;
using TauCode.Mq;

namespace TauCode.WebApi.Testing.Tests.AppHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            var messagePublisher = host.Services.GetService<IMessagePublisher>();
            var messageSubscriber = host.Services.GetService<IMessageSubscriber>();

            messagePublisher.Start();
            messageSubscriber.Start();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
