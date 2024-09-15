# SMSApi



## Project Name

This README file provides information about the Task Management API project.

Description
The SMSApi API project is designed to provide backend functionality for managing tasks. It includes features such as creating, updating, deleting, and retrieving data.

Prerequisites
Before running the project, ensure you have the following prerequisites installed on your system:

.NET Core SDK 8.0
Visual Studio (version 2022)
SQL Server 
Installation
Follow these steps to install and run the project:
GithURL=https://github.com/chameeraart/SMSApi.git
Clone the repository to your local machine.
Open the project in Visual Studio.
Run dotnet restore in the project directory to restore dependencies.
Ensure that your appsettings.json file contains the correct database connection string.
Run "dotnet ef database update" in the project directory to apply migrations and initialize the database.
Run the project in Visual Studio.
Add a service to Services > Seed with the default username and password. Insert: admin, password: admin; username: Devuplink, password: 123.
## Angular Frontend

The project also includes an Angular frontend.

Angular CLI version: 17.1.0
Follow these steps to set up the Angular frontend:

GithURL= https://github.com/chameeraart/SMSUi.git
Clone the repository to your local machine.
Navigate to the Angular project directory.
Run "npm install" to install dependencies.
Modify the config.ts file to specify the API URL. For example, if the API is running at https://localhost:7019, update the apiUrl variable in config.ts accordingly.
After completing these steps, you can run the Angular frontend.

Notes
Ensure that all migrations have been applied to the database before running the application.
The application startup process initializes migrations.
If you encounter issues with the dotnet ef database update command, make sure you have installed the dotnet-ef tool globally using dotnet tool install --global dotnet-ef.

if you need any support contect me. 0768876200










