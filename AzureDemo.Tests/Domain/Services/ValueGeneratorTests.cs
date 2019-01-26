using System.Threading.Tasks;
using AzureDemo.Domain.Services;
using Xunit;

namespace AzureDemo.Tests.Domain.Services
{
    [Trait("Category", "Unit")]
    public class ValueGeneratorTests
    {
        ValueGenerator _valueGenerator;

        public ValueGeneratorTests()
        {
            _valueGenerator = new ValueGenerator();
        }

        [Fact]
        public async Task ValueGenerator_GetValue_ReturnsValueAndNumberPassedIn()
        {
            // Arrange
            int input = 3;
            string expected = "value3";
            string actual;

            // Act
            actual = await _valueGenerator.GetValue(input).ConfigureAwait(false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ValueGenerator_GetValues_ReturnsMultipleValues()
        {
            // Arrange & Act
            var result = await _valueGenerator.GetValues().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}