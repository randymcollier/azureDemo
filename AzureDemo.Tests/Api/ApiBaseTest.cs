using System.Net.Http;
using NUnit.Framework;

namespace AzureDemo.Tests.Api
{
    [TestFixture, Category("Integration")]
    public class ApiBaseTest
    {
        private ApiWebApplicationFactory _factory { get; set; }
        protected HttpClient _httpClient { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new ApiWebApplicationFactory();
            _httpClient = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _httpClient?.Dispose();
            _factory?.Dispose();
        }
    }
}