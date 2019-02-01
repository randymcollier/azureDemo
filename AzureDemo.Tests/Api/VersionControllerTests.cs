using System.Threading.Tasks;
using NUnit.Framework;

namespace AzureDemo.Tests.Api
{
    public class VersionControllerTests : ApiBaseTest
    {
        [Test]
        public async Task VersionController_Get_Returns200()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/version").ConfigureAwait(false);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task VersionController_Get_ReturnsString()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/version").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Assert
            Assert.NotNull(content);
        }
    }
}