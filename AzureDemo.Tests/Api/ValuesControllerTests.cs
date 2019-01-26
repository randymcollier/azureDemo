using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using AzureDemo.Api;

namespace AzureDemo.Tests.Api
{
    [Trait("Category", "Integration")]
    public class ValuesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ValuesControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ValuesController_GetSpecificValue_Returns200()
        {
            // Arrange
            using (var http = _factory.CreateClient())
            {
                // Act
                var response = await http.GetAsync("/api/values/5").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task ValuesController_GetSpecificValue_ReturnsString()
        {
            // Arrange
            using (var http = _factory.CreateClient())
            {
                // Act
                var response = await http.GetAsync("/api/values/5").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Assert
                Assert.NotNull(content);
            }
        }

        [Fact]
        public async Task ValuesController_GetValues_Returns200()
        {
            // Arrange
            using (var http = _factory.CreateClient())
            {
                // Act
                var response = await http.GetAsync("/api/values").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task ValuesController_GetValues_ReturnsListOfStrings()
        {
            // Arrange
            using (var http = _factory.CreateClient())
            {
                // Act
                var response = await http.GetAsync("/api/values").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(content);

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}