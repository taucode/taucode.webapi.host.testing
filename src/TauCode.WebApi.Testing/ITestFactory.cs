using System;
using System.Net.Http;

namespace TauCode.WebApi.Testing
{
    public interface ITestFactory : IDisposable
    {
        HttpClient CreateClient();
        TService GetService<TService>();
    }
}
