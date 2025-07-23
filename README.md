# Football League API

A basic .NET Web API built with Entity Framework Core (Database-First) to manage football league data.

## Features

- Get, add, update, and delete teams and players
- Connected to SQL Server using EF Core
- Swagger UI for easy API testing

## Tech Stack

- .NET 8
- Entity Framework Core (Database-First)
- SQL Server
- Swagger

### Get response:
Retrieve all teams.
<img width="1141" height="920" alt="image" src="https://github.com/user-attachments/assets/3339027c-0024-42ae-aa52-18449a61457b" />

### POST /api/teams
Insert a new team by providing its name and city.
_Post response is now working, as it's inserting the name & city correctly._
<img width="1046" height="499" alt="image" src="https://github.com/user-attachments/assets/b844eff5-52ed-4254-b0c6-749afa8a25bb" />

### Delete Response:
Delete a team by its ID.

- If the team exists and is successfully deleted, the API returns:
  - **HTTP Status:** `204 No Content`  
  - No response body (standard REST behavior)

- If the team does not exist, the API returns:
  - **HTTP Status:** `404 Not Found`

_This is the response after a delete operation performed on a TeamID input from user:_
<img width="1069" height="640" alt="image" src="https://github.com/user-attachments/assets/fa09c379-0743-432d-967b-cc0e04c59cf5" />
