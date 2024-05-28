using DistanceCalculator.API.Calculators;
using Xunit;

namespace DistanceCalculator.API.UnitTests;

public class HaversineDistanceCalculatorTests
{
    private readonly EarthSphericityConfiguration _configuration = new();

    [Fact]
    public async Task CalculateDistance_ValidCoordinates_ReturnsCorrectDistance()
    {
        // Arrange
        const int expectedDistance = 5536;
        var calculator = new HaversineDistanceCalculator(_configuration);
        var pointA = new Coordinates(Latitude: 53.297975, Longitude: -6.372663);
        var pointB = new Coordinates(Latitude: 41.385101, Longitude: -81.440440);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointB);

        // Assert - Expected distance in km
        Assert.Equal(expectedDistance, Math.Round(distance, 0, MidpointRounding.AwayFromZero));
    }

    [Fact]
    public async Task CalculateDistance_SamePoint_ReturnsZero()
    {
        // Arrange
        const int expectedDistance = 0;
        var calculator = new HaversineDistanceCalculator(_configuration);
        var pointA = new Coordinates(Latitude: 53.297975, Longitude: -6.372663);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointA);

        // Assert - In km.
        Assert.Equal(expectedDistance, distance);
    }

    [Theory]
    [InlineData(90, 0, -90, 0, 20015)]
    [InlineData(0, 0, 0, 180, 20015)]
    public async Task CalculateDistance_AntipodalPoints_ReturnsCorrectDistance(
        double latA, 
        double lonA, 
        double latB, 
        double lonB, 
        double expectedDistance)
    {
        // Arrange
        var calculator = new HaversineDistanceCalculator(_configuration);
        var pointA = new Coordinates(Latitude: latA, Longitude: lonA);
        var pointB = new Coordinates(Latitude: latB, Longitude: lonB);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointB);

        // Assert - in km.
        Assert.Equal(expectedDistance, Math.Round(distance, 0, MidpointRounding.AwayFromZero));
    }
}
