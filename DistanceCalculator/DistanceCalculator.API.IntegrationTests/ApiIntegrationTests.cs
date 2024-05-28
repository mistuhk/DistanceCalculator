using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DistanceCalculator.API.IntegrationTests
{
    public class ApiIntegrationTests(WebApplicationFactory<Program> factory) 
        : IClassFixture<WebApplicationFactory<Program>>, IAsyncDisposable
    {
        [Theory]
        [InlineData("/calculate/spherical")]
        [InlineData("/calculate/haversine")]
        [InlineData("/calculate/pythagorean")]
        public async Task CalculateDistance_ValidCoordinates_ReturnsCorrectDistance(string url)
        {
            // Arrange

            // Act

            // Assert

        }

        [Theory]
        [InlineData("/calculate/spherical")]
        [InlineData("/calculate/haversine")]
        [InlineData("/calculate/pythagorean")]
        public async Task CalculateDistance_ValidCoordinates_ReturnsCorrectDistanceInMiles(string url)
        {
            // Arrange

            // Act

            // Assert

        }

        public async ValueTask DisposeAsync() => await factory.DisposeAsync();
    }
}
