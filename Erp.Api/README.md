# Final Project - ERP Api 

This project is a Web Api project containing Api Endpoints to manage enterprise resource planning between company-dealer. 

## Project Description

<p>
    This project was developed as an N-Tier layer project. The technologies and patterns used in the project are listed below.
    <ul>
        <li><strong>Entity Framework</strong> is used to map and interact data in a relational database with objects in an object-oriented programming language.</li>
        <li>InitialData and SeedData migrations were created using the <strong>CodeFirst</strong> approach.</li>
        <li><strong>MsSql</strong> was used as the database. However, PostgreSql database can also be easily adapted.</li>
        <li><strong>JWT Token</strong> was used for authentication and authorization.</li>
        <li><strong>Repository Pattern </strong> was used to abstract database operations..</li>
        <li><strong>Mediatr</strong> was used to manage commands and queries, easily distribute transactions, and react to these transactions.</li>
        <li><strong>Unit of Work</strong> was used to collect and manage all database operations of a transaction within a single business unit.</li>
        <li><strong>Data Transfer Object (DTOs)</strong> were used to avoid carrying unnecessary data on the network or in memory and to reduce the dependency between layers.</li>
    <ul>
</p>


###Postman
<p>
    You can access the endpoint document for Erp.Api from the Postman document link below.
</p>

<div>
    <strong>Erp.Api Endpoints Postman: </strong><a href="https://documenter.getpostman.com/view/29567242/2s9YXk2fj3">documenter.getpostman.com</a>
</div>

## Getting Started

Follow the steps below to run the project on your local machine.

### Installation

- Clone the repo: `git clone https://github.com/enesorhaan/VakifBank-FinalCase.git`
- Navigate to the project directory: `cd Erp.Api`

### Prerequisites

Before you begin, ensure you have the following prerequisites installed:

- [.NET SDK](https://dotnet.microsoft.com/download) must be installed.
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) must be installed.

#### Database Setup

<strong>1. </strong> Create a new database named <strong>'erp.api'</strong> in Microsoft SQL Server.

#### Api Setup

<strong>1. </strong>  Update the connection string in the `appsettings.json` file with your database credentials:

   ```json
   "ConnectionStrings": {
     "MsSqlConnection": "Server=.;Database=erp.api;User id=YourUsername;pwd=YourPassword;Trusted_Connection=True;TrustServerCertificate=True"
   }
   ``` 
<strong> Warning! </strong>Replace YourUsername, and YourPassword with your actual database information.

<strong>2. </strong> To apply migrations files to database (in PowerShell Command Line)
- Navigate to the project directory: `cd sln`
- Run the command line: `dotnet ef database update --project  "./Erp.Data" --startup-project "./Erp.Api"`

<strong>3. </strong> Check that InitialData and SeedData migrations are applied to the database properly

### Setup is Ready!

<strong>Here we go!</strong>

What you need to do now is to start your API application. You can now test your endpoints with Swagger or Postman (linked above).

Swagger Path: https://localhost:44319/swagger

<strong> Note: </strong>Firstly log in to Swagger or Postman for token transactions and do not forget to use the token returned in the response.

<strong> Warning! </strong>To ensure that it works properly with Erp.Panel, it would be best to run it with IIS Express.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.




## What's included

Within the download you'll find the following directories and files, logically grouping common assets and providing both compiled and minified variations. You'll see something like this:

```
Erp.Api
├── Erp.Api/                         # main app directory
│   ├── Controllers/                 # classes that control the API
│   ├── logs/                        # log files
│   ├── Middleware/                  # application middleware
│   ├── appsetting.json/             # application settings
│   ├── Program.cs/                  # the entry point of the application
│   └── Startup.cs/                  # configuration settings when the application starts
│
├── Erp.Base
│   ├── Enum/                        # enumeration types
│   ├── Logger/                      # classes for logging operations
│   ├── Model/                       # common models
│   ├── Response/                    # classes for API responses
│   └── Token/                       # authentication and authorization processes
│   
├── Erp.Data
│   ├── Context/                     # classes defining the database context
│   ├── Entities/                    # database entities
│   ├── Migrations/                  # database migrations
│   ├── Repository/                  # repository classes for database operations
│   └── UoW/                         # Unit of Work pattern
│
├── Erp.Dto                          # Data Transfer Object (DTO) classes
│
└── Erp.Operation
    ├── Command/                     # command-related operations
    ├── Cqrs/                        # Command Query Responsibility Segregation (CQRS) principle
    ├── Mapper/                      # classes for object mapping
    ├── Query/                       # query-related operations
    └── Validation/                  # data validation operations
```
