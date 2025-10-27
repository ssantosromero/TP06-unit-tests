using Xunit;
using SimpleWebAPI.Controllers;

namespace SimpleWebAPI.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Get_ReturnsWeatherData()
        {
            // Arrange
            var controller = new WeatherForecastController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }
    }
}
