using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Nordq.Fortnox.SDK.Tests.Infrastructure
{
    [CollectionDefinition("DefaultCollection")]
    public class Collection : ICollectionFixture<TestContext> { }

    public class TestContext : IDisposable
    {
        public IConfiguration Configuration { get; set; }

        public ServiceProvider ServiceProvider { get; }

        public TestContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).
                AddJsonFile("local.settings.json", optional: true, reloadOnChange: true).
                AddEnvironmentVariables();

            Configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
            ServiceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
