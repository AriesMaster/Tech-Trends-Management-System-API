NWU Tech Trends Management System API
Overview
The NWU Tech Trends Management System provides a set of RESTful APIs for managing and accessing telemetry data. This data tracks the time saved by automations, associating this time saved with cost and grouping it by project and client. The system is designed to work with RESTful APIs, which allow for effective management and interaction with data sources over HTTP.

Authentication
Login
To authenticate and receive a JWT token, send a POST request to /api/Authenticate/login with the following parameters:

username: Your username
password: Your password
Register
To register a new user, send a POST request to /api/Authenticate/register with the following parameters:

username: Your desired username
email: Your email address
password: Your chosen password
Telemetry Management
Retrieve All Telemetry Records
To get all telemetry records, send a GET request to /api/Telemetry.

Retrieve a Specific Telemetry Record
To get a specific telemetry record by ID, send a GET request to /api/Telemetry/{id}.

Create a New Telemetry Record
To add a new telemetry record, send a POST request to /api/Telemetry with the following parameters:

id: Integer identifier for the record
processId: ID of the process
jobId: ID of the job
queueId: ID of the queue
stepDescription: Description of the step
humanTime: Time saved in human-readable format
uniqueReference: Unique reference for the record
uniqueReferenceType: Type of unique reference
businessFunction: Business function associated with the record
geography: Geographic location
excludeFromTimeSaving: Whether to exclude from time-saving calculations
additionalInfo: Any additional information
entryDate: Date of entry
Update a Telemetry Record
To update an existing telemetry record, send a PATCH request to /api/Telemetry/{id} with the updated parameters.

Delete a Telemetry Record
To delete an existing telemetry record, send a DELETE request to /api/Telemetry/{id}.

Check If Telemetry Exists
A private method is available to check if a telemetry record exists based on the ID parsed through before editing or deleting an item.

Calculate Cumulative Savings by Project
To calculate the cumulative time and cost saved per project, send a GET request to /api/Telemetry/GetSavings with the following parameters:

projectId: The ID of the project
startDate: Start date of the range
endDate: End date of the range
Calculate Cumulative Savings by Client
To calculate the cumulative time and cost saved per client, send a GET request to /api/Telemetry/GetSavings with the following parameters:

clientId: The ID of the client
startDate: Start date of the range
endDate: End date of the range
API Design and Usage
The NWU Tech Trends Management System employs RESTful APIs to manage telemetry data effectively. RESTful APIs are commonly used for their simplicity and scalability in connecting applications and data sources. The API follows standard CRUD operations (Create, Read, Update, Delete) to interact with the telemetry data and ensure efficient data management and retrieval.

Security
Ensure that authentication has been correctly implemented and validated for secure access to the API endpoints.
