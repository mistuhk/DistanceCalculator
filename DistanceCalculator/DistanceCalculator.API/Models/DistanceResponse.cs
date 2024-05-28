namespace DistanceCalculator.API.Models;

public class DistanceResponse(double distance, string unit)
{
    public double Distance { get; set; } = distance;
    public string Unit { get; set; } = unit;
}
