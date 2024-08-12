# NWU Tech Trends Management System API

## Overview

The NWU Tech Trends Management System provides a set of RESTful APIs for managing and accessing telemetry data. This data tracks the time saved by automations, associating this time saved with cost and grouping it by project and client. The system is designed to work with RESTful APIs, which allow for effective management and interaction with data sources over HTTP.


![Screenshot 2024-08-12 163512](https://github.com/user-attachments/assets/1488a476-4083-4649-87e9-05a5c91288d3)

## Authentication

### Login

To authenticate and receive a JWT token, send a POST request to `/api/Authenticate/login` with the following parameters:

- `username`: Your username
- `password`: Your password

### Register

To register a new user, send a POST request to `/api/Authenticate/register` with the following parameters:

- `username`: Your desired username
- `email`: Your email address
- `password`: Your chosen password

## Telemetry Management

### Retrieve All Telemetry Records

To get all telemetry records, send a GET request to `/api/Telemetry`.

### Retrieve a Specific Telemetry Record

To get a specific telemetry record by ID, send a GET request to `/api/Telemetry/{id}`.

### Create a New Telemetry Record

To add a new telemetry record, send a POST request to `/api/Telemetry` with the following parameters:

- `id`: Integer identifier for the record
- `processId`: ID of the process
- `jobId`: ID of the job
- `queueId`: ID of the queue
- `stepDescription`: Description of the step
- `humanTime`: Time saved in human-readable format
- `uniqueReference`: Unique reference for the record
- `uniqueReferenceType`: Type of unique reference
- `businessFunction`: Business function associated with the record
- `geography`: Geographic location
- `excludeFromTimeSaving`: Whether to exclude from time-saving calculations
- `additionalInfo`: Any additional information
- `entryDate`: Date of entry

### Update a Telemetry Record

To update an existing telemetry record, send a PATCH request to `/api/Telemetry/{id}` with the updated parameters.

### Delete a Telemetry Record

To delete an existing telemetry record, send a DELETE request to `/api/Telemetry/{id}`.

### Check If Telemetry Exists

A private method is available to check if a telemetry record exists based on the ID parsed through before editing or deleting an item.

### Calculate Cumulative Savings by Project

To calculate the cumulative time and cost saved per project, send a GET request to `/api/Telemetry/GetSavings` with the following parameters:

- `projectId`: The ID of the project
- `startDate`: Start date of the range
- `endDate`: End date of the range

### Calculate Cumulative Savings by Client

To calculate the cumulative time and cost saved per client, send a GET request to `/api/Telemetry/GetSavings` with the following parameters:

- `clientId`: The ID of the client
- `startDate`: Start date of the range
- `endDate`: End date of the range

## API Design and Usage

The NWU Tech Trends Management System employs RESTful APIs to manage telemetry data effectively. RESTful APIs are commonly used for their simplicity and scalability in connecting applications and data sources. The API follows standard CRUD operations (Create, Read, Update, Delete) to interact with the telemetry data and ensure efficient data management and retrieval.

## Security

Ensure that authentication has been correctly implemented and validated for secure access to the API endpoints.

# Project Requirements and Learnings

## CRUD RESTful API Implementation

- **GET**: Retrieve data from the server.
- **POST**: Create new data entries.
- **PATCH**: Update existing data entries.
- **DELETE**: Remove data entries from the server.

**What I Learned:**
Understanding how to create and manage API endpoints for different operations is crucial for developing robust web services. It helps in handling data interactions in a standardized way.

## Database Connection Using Entity Framework Core

- **Entity Framework Core (EF Core)**: An Object-Relational Mapper (ORM) that connects your API to a database, allowing you to interact with the database using .NET objects.

**What I Learned:**
I gained experience in setting up and configuring EF Core, which is essential for efficient database management and operations. This includes creating models, configuring DbContexts, and managing migrations.

## Managing and Querying Telemetry Data

- Implement functionality to handle telemetry data, including recording, updating, and querying this data based on specific criteria.

**What I Learned:**
Handling specific types of data (like telemetry) and developing features to query and manage this data is valuable for understanding data management in real-world applications. It also includes skills in creating effective queries and processing data.

## Security and Authentication

- Ensure that your API is secure and only accessible by authorized users. This typically involves implementing authentication mechanisms (like JWT tokens) and configuring appropriate security policies.

**What I Learned:**
Implementing security measures is critical for protecting data and ensuring that only authorized users can access certain parts of your API. This is important for maintaining data privacy and integrity.

## Hosting on Azure and GitHub Management

- Deploy your API to Azure, a cloud service provider, and keep your project updated on GitHub.

**What I Learned:**
Hosting on Azure gave me practical experience with cloud services and deployment practices. Managing my code on GitHub helped me understand version control and collaboration in a development environment.



## References

- Microsoft Docs (n.d.). *Tutorial: Create a web API with ASP.NET Core*. Available at: [https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0) (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *Create a web API with ASP.NET Core controllers*. Available at: [https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/?view=aspnetcore-5.0](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/?view=aspnetcore-5.0) (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *ASP.NET Core web API documentation with Swagger / OpenAPI*. Available at: [https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0) (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *Create microservices with .NET and ASP.NET Core*. Available at: [https://docs.microsoft.com/en-us/dotnet/architecture/microservices/](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/) (Accessed: 12 August 2024).

- Microsoft (2020). *Entity Framework Core 3.1 - Getting Started*. Available at: [https://docs.microsoft.com/en-us/ef/core/get-started/](https://docs.microsoft.com/en-us/ef/core/get-started/) (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *Join two entities in .NET Core, using lambda and Entity Framework Core*. Available at: [https://docs.microsoft.com/en-us/ef/core/querying/](https://docs.microsoft.com/en-us/ef/core/querying/) (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *Publish an ASP.NET Core web API to Azure API Management with Visual Studio*. Available at: [https://docs.microsoft.com/en-us/azure/api-management/publish-aspnet-core-web-api-visual-studio](https://docs.microsoft.com/en-us/azure/api-management/publish-aspnet-core-web-api-visual-studio) (Accessed: 12 August 2024).

- Pape, R. (n.d.). *Automating ASP.NET Core Web API Creation That Communicates with Your Database in 60 Seconds or Less*. Available at: [URL] (Accessed: 12 August 2024).

- Microsoft Docs (n.d.). *Quickstart: Create a .NET Core app in Azure App Service*. Available at: [https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net80&pivots=development-environment-vs#launch-the-publish-wizard?utm_source=aspnet-start-page&utm_campaign=vside](https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net80&pivots=development-environment-vs#launch-the-publish-wizard?utm_source=aspnet-start-page&utm_campaign=vside) (Accessed: 12 August 2024).

## References lists Doc


[reference list.pdf](https://github.com/user-attachments/files/16588317/reference.list.pdf)
