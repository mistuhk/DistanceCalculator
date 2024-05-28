namespace DistanceCalculator.API.Calculators;

public class PythagoreanDistanceCalculator : DistanceCalculatorBase, IDistanceCalculator
{
    /// <summary>
    /// Calculates the distance between two points (small distances) **** an approximation ***
    /// where the curvature of the Earth can be ignored, as it treats the Earth as flat over small distances.
    /// https://en.wikipedia.org/wiki/Pythagorean_theorem
    /// </summary>
    /// <param name="pointA"><see cref="Coordinates"/>Point of interest</param>
    /// <param name="pointB"><see cref="Coordinates"/>Point of interest</param>
    /// <returns>Distance between points in km</returns>
    public override async Task<double> CalculateDistance(Coordinates pointA, Coordinates pointB)
    {
        double dLat = pointB.Latitude - pointA.Latitude;
        double dLon = pointB.Longitude - pointA.Longitude;

        double distance = Math.Sqrt(dLat * dLat + dLon * dLon);

        // Approximate conversion from degrees to km
        return await Task.FromResult(distance * 111);
    }
}
