namespace DistanceCalculator.API.Calculators;

public class HaversineDistanceCalculator(IEarthSphericityConfiguration configuration)
    : DistanceCalculatorBase, IDistanceCalculator
{
    /// <summary>
    /// Calculates the distance between two points using the haversine formula.
    /// https://community.esri.com/t5/coordinate-reference-systems-blog/distance-on-a-sphere-the-haversine-formula/ba-p/902128
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

        double dLat = latB - latA;
        double dLon = lonB - lonA;

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(latA) * Math.Cos(latB) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return await Task.FromResult(configuration.EarthRadiusKm * c);
    }
}
