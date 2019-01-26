using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AzureDemo.Tests.Api
{
    [Trait("Category", "Integration")]
    public class ValuesControllerTests
    {
        private readonly string _stagingUrl = "http://azuredemo12944-staging.azurewebsites.net";
        
        [Fact]
        public async Task ValuesController_GetSpecificValue_Returns200()
        {
            // Arrange
            using (var http = new HttpClient())
            {
                // Act
                var response = await http.GetAsync($"{_stagingUrl}/api/values/5").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task ValuesController_GetSpecificValue_ReturnsString()
        {
            // Arrange
            using (var http = new HttpClient())
            {
                // Act
                var response = await http.GetAsync($"{_stagingUrl}/api/values/5").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Assert
                Assert.NotNull(content);
            }
        }

        [Fact]
        public async Task ValuesController_GetValues_Returns200()
        {
            // Arrange
            using (var http = new HttpClient())
            {
                // Act
                var response = await http.GetAsync($"{_stagingUrl}/api/values").ConfigureAwait(false);

                // Assert
                Assert.True(response.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task ValuesController_GetValues_ReturnsListOfStrings()
        {
            // Arrange
            using (var http = new HttpClient())
            {
                // Act
                var response = await http.GetAsync($"{_stagingUrl}/api/values").ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(content);

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}