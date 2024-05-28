using DistanceCalculator.API.Calculators;
using DistanceCalculator.API.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Wait 30 seconds for graceful shutdown.
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

// Add Swagger Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Distance Calculator API",
        Description = "Enables calculation of the distance between two points.",
        Version = "v1"
    });
});

// Add services to the container.
builder.Services.AddScoped<IEarthSphericityConfiguration, EarthSphericityConfiguration>();
builder.Services.AddKeyedScoped<IDistanceCalculator, SphericalDistanceCalculator>(nameof(SphericalDistanceCalculator));
builder.Services.AddKeyedScoped<IDistanceCalculator, HaversineDistanceCalculator>(nameof(HaversineDistanceCalculator));
builder.Services.AddKeyedScoped<IDistanceCalculator, PythagoreanDistanceCalculator>(nameof(PythagoreanDistanceCalculator));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Distance Calculator API v1");
});

// Register endpoints
app.RegisterEndpoints();

app.Run();


public partial class Program { }