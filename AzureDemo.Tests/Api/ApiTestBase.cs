using AzureDemo.Tests.Utilities;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AzureDemo.Tests.Api
{
    [SetUpFixture]
    public class ApiTestBase
    {
        protected ApiWebApplicationFactory _factory;
        private Environment _environment;

        [OneTimeSetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                                .AddJsonFile("testsettings.json")
                                .Build();
            var env = config["Environment"];
            _environment = EnvironmentHelper.GetEnvironment(env);
            _factory = new ApiWebApplicationFactory(_environment);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _factory?.Dispose();
        }
    }
}