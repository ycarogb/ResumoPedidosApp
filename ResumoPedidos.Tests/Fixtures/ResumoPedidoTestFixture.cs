using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace ResumoPedidos.Tests.Fixtures;

public class ResumoPedidoTestFixture: TestFixtureBase, IDisposable
{
    private TestServer _testServer;

    public override IServiceProvider Provider => _testServer.Host.Services;
    public override HttpClient Client => _testServer.CreateClient();

    public void Dispose()
    {
        _testServer?.Dispose();
    }

    private static readonly Dictionary<string, string> DefaultSettings = new()
    {
        ["SUPPORTED_CULTURES"] = "pt-BR",
    };
    
    internal void EnsureReady(Type testClassType)
    {
        if (_testServer != null) return;
        
        var builder = CreateWebHostBuilder();
        //TODO: CRIAR UMA STARTUP PARA USAR .UseStartup<Startup>
        _testServer = new TestServer(builder) { AllowSynchronousIO = true };
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
    }
    private WebHostBuilder CreateWebHostBuilder()
    {
        var builder = new WebHostBuilder();
        builder.UseEnvironment("Development");
        builder.ConfigureAppConfiguration(ConfigureAppConfiguration);
        return builder;
    }

    protected virtual void ConfigureAppConfiguration(IConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.AddInMemoryCollection(DefaultSettings);
        configurationBuilder.AddEnvironmentVariables();
    }
    
}
