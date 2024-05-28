#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project files and restore dependencies 
COPY ["DistanceCalculator.API/DistanceCalculator.API.csproj", "DistanceCalculator.API/"]
RUN dotnet restore "./DistanceCalculator.API/DistanceCalculator.API.csproj"

# Copy the rest of the application code
COPY . .

WORKDIR "/src/DistanceCalculator.API"
RUN dotnet build "./DistanceCalculator.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish to designated build directory
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DistanceCalculator.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime stage - excludes debug symbols/artefacts from deployment
FROM base AS final
WORKDIR /app

# Copy the publish output from the build stage
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DistanceCalculator.API.dll"]