# DistanceCalculator

**OVERVIEW**

The solution is split into 4 sub-projects and these are as follows:

**DistanceCaculator.API:** This is the API application that serves user requests. Adds support for SwaggerUI.

![image](https://github.com/mistuhk/DistanceCalculator/assets/5063063/0da2e0cd-9ec3-40f8-af4c-30e49497d084)


**DistanceCaculator.API.EndpointGenerator:** This project dynamically generates the endpoint definition for the API using IIncrementalGenerator interface.
As this API uses the minimal API spec, it ensures that endpoints don't have to be explicitly defined in the startup [Program.cs] class.

Defined endpoints [templates] would be scanned during build and an endpoint mapping extension would be generated, and it automatically registers all detected endpoints on startup.

![image](https://github.com/mistuhk/DistanceCalculator/assets/5063063/1a2e3ee9-4573-4226-bead-20366538e837)


**DistanceCaculator.API.IntegrationTests**: The integration tests projects.

**DistanceCaculator.API.UnitTests**: The unit tests project.


**HOW TO RUN THE APP**

Containerisation has been implemented in the application, this means that the "DistanceCaculator.API" can be started without having to install dependencies locally (other than having docker CLI available).

To run the application...

In the solution directory, locate the **docker-compose.yml** file.

In the CLI, execute **docker compose up -d --build**.

This will spin up a container for the API.

The API can be accessed using the url: **http://localhost:5223/**

The API's Swagger UI can be accessed using the url: **<http://localhost:5223/swagger/index.html>**


**HOW TO STOP THE APP**
Execute **docker compose stop** to abort execution of the app.

Execute **docker compose down** to remove the container and its dependent resources.

NOTE:
In the DistanceCalculator.API, there's a **DistanceCalculator.API.EndpointGenerator.http** file that specifies a few integration tests that can be executed outside of the tests in the dedicated test projects.

![image](https://github.com/mistuhk/DistanceCalculator/assets/5063063/98966104-165b-492f-90de-7ce3b0bf258e)



This requires that the API is running [i.e. docker compose up has been executed]. However, the tests in the integration tests projects do not require the application to be running.
