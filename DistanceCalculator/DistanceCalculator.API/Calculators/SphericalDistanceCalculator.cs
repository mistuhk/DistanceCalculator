namespace DistanceCalculator.API.Calculators;

public class SphericalDistanceCalculator(IEarthSphericityConfiguration configuration)
    : DistanceCalculatorBase, IDistanceCalculator
{
    /// <summary>
    /// Calculates the distance between two points using the spherical cosine law.
    /// https://en.wikipedia.org/wiki/Great-circle_distance#Formulas
    /// https://cuhkmath.wordpress.com/2010/10/04/spherical-cosine-law/
    /// </summary>
    /// <param name="pointA"><see cref="Coordinates"/>Point of interest</param>
    /// <param name="pointB"><see cref="Coordinates"/>Point of interest</param>
    /// <returns>Distance between points in km</returns>
    public override async Task<double> CalculateDistance(Coordinates pointA, Coordinates pointB)
    {
        double latA = DegreesToRadians(pointA.Latitude);
        double lonA = DegreesToRadians(pointA.Longitude);
        double latB = DegreesToRadians(pointB.Latitude);
        double lonB = DegreesToRadians(pointB.Longitude);

        double deltaLon = lonB - lonA;
        double centralAngle = Math.Acos(Math.Sin(latA) * Math.Sin(latB) +
                                        Math.Cos(latA) * Math.Cos(latB) * Math.Cos(deltaLon));

        return await Task.FromResult(configuration.EarthRadiusKm * centralAngle);
    }
}
