using AzureDemo.Tests.Utilities;
using NUnit.Framework;

namespace AzureDemo.Tests.Api
{
    [SetUpFixture]
    public class ApiTestBase
    {
        protected ApiWebApplicationFactory _factory;
        private string _baseUrl;

        [OneTimeSetUp]
        public void Setup()
        {
            var env = TestContext.Parameters["Environment"];
            _baseUrl = EnvironmentHelper.GetBaseUrl(env);
            _factory = new ApiWebApplicationFactory(_baseUrl);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _factory?.Dispose();
        }
    }
}