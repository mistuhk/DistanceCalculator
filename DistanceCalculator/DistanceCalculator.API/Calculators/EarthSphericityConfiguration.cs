namespace DistanceCalculator.API.Calculators;

public record Coordinates(double Latitude, double Longitude)
{
    public double Latitude { get; set; } = Latitude;
    public double Longitude { get; set; } = Longitude;
}

public interface IEarthSphericityConfiguration
{
    double EarthRadiusKm { get; }
}

public sealed record EarthSphericityConfiguration : IEarthSphericityConfiguration
{
    public double EarthRadiusKm { get; } = 6371.0;
}

public interface IDistanceCalculator
{
    Task<double> CalculateDistance(Coordinates pointA, Coordinates pointB);
}

public abstract class DistanceCalculatorBase : IDistanceCalculator
{
    /// <summary>
    /// Calculates the distance between two points.
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <returns>Distance in km.</returns>
    public abstract Task<double> CalculateDistance(Coordinates pointA, Coordinates pointB);

    /// <summary>
    /// Transforms coordinates from degrees to rads.
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns></returns>
    protected virtual double DegreesToRadians(double degrees) => degrees * Math.PI / 180.0;
}

