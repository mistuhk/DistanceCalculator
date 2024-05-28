using DistanceCalculator.API.Calculators;

namespace DistanceCalculator.API.Models;

public class CalculateDistanceRequest(string locale, Coordinates[] coordinates)
{
    public string Locale { get; set; } = locale;
    public Coordinates[] Coordinates { get; set; } = coordinates;
}
