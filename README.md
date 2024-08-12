NWU Tech Trends Management System API Guide
Overview
The NWU Tech Trends Management System provides a set of RESTful APIs for managing and accessing telemetry data, which tracks the time saved by automations. This guide explains how to use the API to authenticate users, manage telemetry records, and retrieve savings data.

Authentication
Login
To authenticate and receive a JWT token, send a POST request to /api/Authenticate/login with the following parameters:

Request URL: https://localhost:7039/api/Authenticate/login

Request Body:

json
Copy code
{
  "username": "Thabo",
  "password": "Thabo1999@"
}
Response:

json
Copy code
{
  "token": "your_jwt_token_here",
  "expiration": "2024-08-12T16:03:08Z"
}
Use this token in the Authorization header for subsequent requests.

Register
To register a new user, send a POST request to /api/Authenticate/register with the following parameters:

Request URL: https://localhost:7039/api/Authenticate/register

Request Body:

json
Copy code
{
  "username": "Thabo",
  "email": "user@example.com",
  "password": "Thabo1999@"
}
Response:

json
Copy code
{
  "status": "Success",
  "message": "User created successfully!"
}
Telemetry Management
Retrieve All Telemetry Records
To get all telemetry records, send a GET request to /api/Telemetry:

Request URL: https://localhost:7039/api/Telemetry

Response:

json
Copy code
[
  {
    "id": 1,
    "processId": "9d3c7f06-dcb1-4430-b264-d6bdaf577345",
    "jobId": "Job1",
    "queueId": "Queue1",
    "stepDescription": "Step 1",
    "humanTime": 100,
    "uniqueReference": "Ref1",
    "uniqueReferenceType": "Type1",
    "businessFunction": "Finance",
    "geography": "Global",
    "excludeFromTimeSaving": false,
    "additionalInfo": "Info1",
    "entryDate": "2024-08-12T00:00:00"
  },
  ...
]
Create a New Telemetry Record
To add a new telemetry record, send a POST request to /api/Telemetry with the following parameters:

Request URL: https://localhost:7039/api/Telemetry

Request Body:

json
Copy code
{
  "id": 0,
  "processId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "jobId": "6",
  "queueId": "87",
  "stepDescription": "Debugging",
  "humanTime": 9,
  "uniqueReference": "string",
  "uniqueReferenceType": "string",
  "businessFunction": "string",
  "geography": "Mzansi",
  "excludeFromTimeSaving": true,
  "additionalInfo": "string",
  "entryDate": "2024-08-12T13:04:08.686Z"
}
Response:

json
Copy code
{
  "id": 6,
  "processId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "jobId": "6",
  "queueId": "87",
  "stepDescription": "Debugging",
  "humanTime": 9,
  "uniqueReference": "string",
  "uniqueReferenceType": "string",
  "businessFunction": "string",
  "geography": "Mzansi",
  "excludeFromTimeSaving": true,
  "additionalInfo": "string",
  "entryDate": "2024-08-12T00:00:00Z"
}
Retrieve a Specific Telemetry Record
To get a specific telemetry record by ID, send a GET request to /api/Telemetry/{id}:

Request URL: https://localhost:7039/api/Telemetry/1

Response:

json
Copy code
{
  "id": 1,
  "processId": "9d3c7f06-dcb1-4430-b264-d6bdaf577345",
  "jobId": "Job1",
  "queueId": "Queue1",
  "stepDescription": "Step 1",
  "humanTime": 100,
  "uniqueReference": "Ref1",
  "uniqueReferenceType": "Type1",
  "businessFunction": "Finance",
  "geography": "Global",
  "excludeFromTimeSaving": false,
  "additionalInfo": "Info1",
  "entryDate": "2024-08-12T00:00:00"
}
Update a Telemetry Record
To update an existing telemetry record, send a PATCH request to /api/Telemetry/{id} with the updated data:

Request URL: https://localhost:7039/api/Telemetry/1

Request Body:

json
Copy code
{
  "stepDescription": "Updated Step"
}
Response: 200 OK

Delete a Telemetry Record
To delete a telemetry record, send a DELETE request to /api/Telemetry/{id}:

Request URL: https://localhost:7039/api/Telemetry/1

Response: 200 OK

Calculating Savings
Get Savings by Project
To calculate the savings by project, send a GET request to /api/Telemetry/GetSavingsByProject:

Request URL: https://localhost:7039/api/Telemetry/GetSavingsByProject?projectId=your_project_id&startDate=2024-08-01T00:00:00Z

Response: The response will include savings data grouped by the project.

Get Savings by Client
To calculate the savings by client, send a GET request to /api/Telemetry/GetSavingsByClient:

Request URL: https://localhost:7039/api/Telemetry/GetSavingsByClient?clientId=your_client_id&startDate=2024-08-01T00:00:00Z

Response: The response will include savings data grouped by the client.
