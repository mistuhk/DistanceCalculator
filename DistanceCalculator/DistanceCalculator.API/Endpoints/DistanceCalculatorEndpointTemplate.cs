using System.Globalization;
using DistanceCalculator.API.Calculators;
using DistanceCalculator.API.Models;

namespace DistanceCalculator.API.Endpoints;

public interface IEndpoint
{
    void MapEndpoints(IEndpointRouteBuilder builder);
}

public class DistanceCalculatorEndpointTemplate : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/calculate/spherical", async (
            CalculateDistanceRequest request,
            [FromKeyedServices(nameof(SphericalDistanceCalculator))] IDistanceCalculator calculator) =>
        {
            if (request.Coordinates.Length != 2)
            {
                return Results.BadRequest("Two coordinates are required.");
            }

            var pointA = request.Coordinates[0];
            var pointB = request.Coordinates[1];

            var distanceKm = await calculator.CalculateDistance(pointA, pointB);
            var unit = "km";
            var distance = distanceKm;

            var locale = string.IsNullOrWhiteSpace(request.Locale.Trim()) ? CultureInfo.CurrentCulture.Name : request.Locale;
            if (string.Equals(locale.Trim(), "en-GB", StringComparison.InvariantCultureIgnoreCase))
            {
                distance = distanceKm * 0.621371; // Convert km to miles
                unit = "miles";
            }

            return Results.Ok(new DistanceResponse(distance, unit));
        });

        builder.MapPost("/calculate/haversine", async (
            CalculateDistanceRequest request,
            [FromKeyedServices(nameof(HaversineDistanceCalculator))] IDistanceCalculator calculator) =>
        {
            if (request.Coordinates.Length != 2)
            {
                return Results.BadRequest("Two coordinates are required.");
            }

            var pointA = request.Coordinates[0];
            var pointB = request.Coordinates[1];

            var distanceKm = await calculator.CalculateDistance(pointA, pointB);
            var unit = "km";
            var distance = distanceKm;

            var locale = string.IsNullOrWhiteSpace(request.Locale.Trim()) ? CultureInfo.CurrentCulture.Name : request.Locale;
            if (string.Equals(locale.Trim(), "en-GB", StringComparison.InvariantCultureIgnoreCase))
            {
                distance = distanceKm * 0.621371; // Convert km to miles
                unit = "miles";
            }

            return Results.Ok(new DistanceResponse(distance, unit));
        });

        builder.MapPost("/calculate/pythagorean", async (
            CalculateDistanceRequest request,
            [FromKeyedServices(nameof(PythagoreanDistanceCalculator))] IDistanceCalculator calculator) =>
        {
            if (request.Coordinates.Length != 2)
            {
                return Results.BadRequest("Two coordinates are required.");
            }

            var pointA = request.Coordinates[0];
            var pointB = request.Coordinates[1];

            var distanceKm = await calculator.CalculateDistance(pointA, pointB);
            var unit = "km";
            var distance = distanceKm;

            var locale = string.IsNullOrWhiteSpace(request.Locale) ? CultureInfo.CurrentCulture.Name : request.Locale;
            if (string.Equals(locale, "en-GB", StringComparison.InvariantCultureIgnoreCase))
            {
                distance = distanceKm * 0.621371; // Convert km to miles
                unit = "miles";
            }

            return Results.Ok(new DistanceResponse(distance, unit));
        });
    }
}
