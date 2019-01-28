using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using AzureDemo.Api;

namespace AzureDemo.Tests.Api
{
    [TestFixture, Category("Integration")]
    public class ValuesControllerTests : ApiTestBase
    {
        [Test]
        public async Task ValuesController_GetSpecificValue_Returns200()
        {
            // Arrange
            using (var http = _factory.GetHttpClient())
            {
                // Act
                var response = await http.GetAsync("api/values/5").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Test]
        public async Task ValuesController_GetSpecificValue_ReturnsString()
        {
            // Arrange
            using (var http = _factory.GetHttpClient())
            {
                // Act
                var response = await http.GetAsync("api/values/5").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Assert
                Assert.NotNull(content);
            }
        }

        [Test]
        public async Task ValuesController_GetValues_Returns200()
        {
            // Arrange
            using (var http = _factory.GetHttpClient())
            {
                // Act
                var response = await http.GetAsync("api/values").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Test]
        public async Task ValuesController_GetValues_ReturnsListOfStrings()
        {
            // Arrange
            using (var http = _factory.GetHttpClient())
            {
                // Act
                var response = await http.GetAsync("api/values").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(content);

                // Assert
                Assert.NotNull(result);
                Assert.IsNotEmpty(result);
            }
        }
    }
}