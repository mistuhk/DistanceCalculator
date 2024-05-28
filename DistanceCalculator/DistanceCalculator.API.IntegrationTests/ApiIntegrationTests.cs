using System.Net.Http.Json;
using DistanceCalculator.API.Calculators;
using DistanceCalculator.API.Models;
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
        public async Task CalculateDistance_ValidCoordinates_ReturnsCorrectDistanceInKm(string url)
        {
            // Arrange
            const string expectedUnit = "km";

            var client = factory.CreateClient();
            var request = new CalculateDistanceRequest(
                "en-IE",
                [
                    new Coordinates(Latitude: 53.297975, Longitude: -6.372663),
                    new Coordinates(Latitude : 41.385101, Longitude : -81.440440)
                ]);

            // Act
            var response = await client.PostAsJsonAsync($"{url}", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<DistanceResponse>();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUnit, result.Unit);
        }

        [Theory]
        [InlineData("/calculate/spherical")]
        [InlineData("/calculate/haversine")]
        [InlineData("/calculate/pythagorean")]
        public async Task CalculateDistance_ValidCoordinates_ReturnsCorrectDistanceInMiles(string url)
        {
            // Arrange
            const string expectedUnit = "miles";

            var client = factory.CreateClient();
            var request = new CalculateDistanceRequest(
                string.Empty,
                [
                    new Coordinates(Latitude: 53.297975, Longitude: -6.372663),
                    new Coordinates(Latitude : 41.385101, Longitude : -81.440440)
                ]);

            // Act
            var response = await client.PostAsJsonAsync($"{url}", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<DistanceResponse>();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUnit, result.Unit);
        }

        public async ValueTask DisposeAsync() => await factory.DisposeAsync();
    }
}
