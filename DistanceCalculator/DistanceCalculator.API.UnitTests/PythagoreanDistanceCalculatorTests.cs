using DistanceCalculator.API.Calculators;
using Xunit;

namespace DistanceCalculator.API.UnitTests;

// Approximate calculation based on Pythagoras method
public class PythagoreanDistanceCalculatorTests
{
    [Fact]
    public async Task CalculateDistance_ValidCoordinates_ReturnsApproximateDistance()
    {
        // Arrange
        const int expectedDistance = 5092;

        var calculator = new PythagoreanDistanceCalculator();
        var pointA = new Coordinates(Latitude: 53.297975, Longitude: -6.372663);
        var pointB = new Coordinates(Latitude: 41.385101, Longitude: -81.440440);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointB);

        // Assert - in km.
        Assert.Equal(expectedDistance, distance, 1);
    }

    [Fact]
    public async Task CalculateDistance_SamePoint_ReturnsZero()
    {
        // Arrange
        const int expectedDistance = 0;

        var calculator = new PythagoreanDistanceCalculator();
        var pointA = new Coordinates(Latitude: 53.297975, Longitude: -6.372663);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointA);

        // Assert - in km.
        Assert.Equal(expectedDistance, distance);
    }

    [Theory]
    [InlineData(53.297975, -6.372663, 53.297975, -6.372663, 0)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(90, 0, -90, 0, 20020.0)] 
    public async Task CalculateDistance_SpecificPoints_ReturnsCorrectDistance(
        double latA, 
        double lonA, 
        double latB, 
        double lonB, 
        double expectedDistance)
    {
        // Arrange
        var calculator = new PythagoreanDistanceCalculator();
        var pointA = new Coordinates(Latitude: latA, Longitude: lonA);
        var pointB = new Coordinates(Latitude: latB, Longitude: lonB);

        // Act
        var distance = await calculator.CalculateDistance(pointA, pointB);

        // Assert - in km.
        Assert.Equal(expectedDistance, distance, 1);
    }
}


