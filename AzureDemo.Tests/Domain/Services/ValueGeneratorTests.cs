using System.Threading.Tasks;
using AzureDemo.Domain.Services;
using NUnit.Framework;

namespace AzureDemo.Tests.Domain.Services
{
    [TestFixture, Category("Unit")]
    public class ValueGeneratorTests
    {
        ValueGenerator _valueGenerator;

        public ValueGeneratorTests()
        {
            _valueGenerator = new ValueGenerator();
        }

        [Test]
        public async Task ValueGenerator_GetValue_ReturnsValueAndNumberPassedIn()
        {
            // Arrange
            int input = 3;
            string expected = "value3";
            string actual;

            // Act
            actual = await _valueGenerator.GetValue(input).ConfigureAwait(false);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task ValueGenerator_GetValues_ReturnsMultipleValues()
        {
            // Arrange & Act
            var result = await _valueGenerator.GetValues().ConfigureAwait(false);

            // Assert
            Assert.IsNotEmpty(result);
        }
    }
}