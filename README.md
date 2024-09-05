# InMemory CRUD API

![Swagger UI](https://github.com/user-attachments/assets/efd53f84-c3f6-489d-943f-e98495b236eb)

This project implements a basic **CRUD API** for managing employee data using **in-memory storage** in **ASP.NET Core**. It provides operations to **create**, **read**, **update**, and **delete** employees and also includes Swagger documentation for easy testing and interaction.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
  - [Swagger UI](#swagger-ui)
  - [Employee CRUD Operations](#employee-crud-operations)
- [Project Structure](#project-structure)
- [Contribution](#contribution)
- [License](#license)

## Technologies Used

- **ASP.NET Core 8.0**
- **C#**
- **Swagger UI (OpenAPI)** for API documentation
- **In-Memory Data Storage**

## Getting Started

### Prerequisites

Ensure you have the following installed on your development machine:

- **.NET 8 SDK or later**: [Install .NET](https://dotnet.microsoft.com/download)
- **Visual Studio 2022** or **JetBrains Rider**

### Installation

1. Clone or download the repository.

2. Extract the project files and navigate to the root directory of the project.

3. Restore dependencies by running the following command in the root folder:

   ```bash
   dotnet restore
   ```

4. Build the project:

   ```bash
   dotnet build
   ```

## Running the Application

To run the project locally, follow these steps:

1. Open a terminal in the project directory.

2. Run the application:

   ```bash
   dotnet run
   ```

3. Open your browser and navigate to the Swagger UI to explore the available API endpoints:

   ```bash
   https://localhost:<PORT>/swagger/index.html
   ```

Here, <PORT> is the port number shown when the application is started.

## Running the Application

### Swagger UI

The project includes Swagger UI for easy testing and interaction with the API. It provides comprehensive documentation for all available endpoints.

You will see a user interface similar to the one shown above where you can interact with the API by making GET, POST, PUT, and DELETE requests.

## Employee CRUD Operations

Here are the available API operations for managing employees:

- GET /api/Employee: Get a paginated list of employees.
- POST /api/Employee: Add a new employee.
- GET /api/Employee/{id}: Get employee details by ID.
- PUT /api/Employee/{id}: Update an existing employee.
- DELETE /api/Employee/{id}: Remove an employee by ID.

## Example Responses

Successful Response (List of Employees):

   ```json
    {
      "status": true,
      "message": "Employees retrieved successfully",
      "time": 1725570135430,
      "data": {
        "page": 1,
        "size": 5,
        "totalItems": 10,
        "totalPages": 2,
        "items": [
          {
            "employeeID": 1,
            "fullName": "John Doe",
            "birthDate": "1990-01-01T00:00:00"
          }
        ]
      }
    }
   ```

Error Response (Employee Not Found):

   ```json
    {
      "status": false,
      "message": "Employee not found",
      "time": 1725570135430,
      "data": null
    }
   ```

#### Project Structure

The project is structured in a way that separates concerns, making it easy to extend and maintain:

```bash
InMemoryCRUD/
│
├── Controllers/            # Contains API controllers
│   └── EmployeeController.cs
│
├── DTOs/                   # Data Transfer Objects (Request and Response Models)
│   ├── Request/
│   └── Response/
│
├── Models/                 # Business entities (e.g., Employee.cs)
│
├── Repositories/           # In-memory data repository for employees
│   └── EmployeeRepository.cs
│
├── Services/               # Business logic layer
│   ├── Interfaces/
│   └── EmployeeService.cs
│
├── Program.cs              # Entry point of the application
│
├── appsettings.json        # Application settings
└── appsettings.Development.json # Development-specific settings
```

### Key Files:

- Program.cs: Configures the application and sets up routing, Swagger, and in-memory data.
- EmployeeController.cs: Handles incoming HTTP requests related to employee management.
- EmployeeService.cs: Contains the business logic for managing employees.
- EmployeeRepository.cs: Acts as an in-memory database to store and retrieve employee data.
- DTOs: Used to transfer data between the client and the server (both request and response).

### Contribution

Feel free to fork the project, create a feature branch, and submit a pull request for any improvements or new features.

### License

This project is licensed under the MIT License.
