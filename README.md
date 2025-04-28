Hikru Code Challenge

This repository contains the implementation of a full-stack code challenge using:

Backend: .NET 8 API with Clean Architecture, MediatR, CQRS, FluentValidation
Frontend: Angular 19 with Standalone Components, Reactive Forms

🛠 Tech Stack

Backend: .NET 8, ASP.NET Core Web API
Patterns: Clean Architecture, CQRS with MediatR
Database: InMemory EF Core
Frontend: Angular 19, Standalone Components
Styling: SCSS (basic)
Communication: HttpClient + Interceptor (API Key)
Testing: xUnit, Moq, FluentAssertions, Angular Testing Library

📚 How to Run the Project

Backend (API):

Navigate to the server/ folder

Restore dependencies: dotnet restore

Run the API: dotnet run --project API

Swagger will be available at: https://localhost:7252/swagger (Or the port assigned by your environment. Click "Authorize" and enter API Key: da1d2d28-92ed-4a2e-a1a9-10fcf4425f15)

Frontend (Angular):

Navigate to the client/ folder

Install dependencies: npm install

Run the app: npm start

Application will open at: http://localhost:4200

The list of positions is shown by default on app load.

🔐 API Key

All API requests require the header:

X-API-KEY: da1d2d28-92ed-4a2e-a1a9-10fcf4425f15

Handled automatically by Angular Http Interceptor.

🔢 Sample Recruiter and Department IDs

When creating or updating a position, you can use the following IDs:

Recruiters:
- 5d8652c8-456b-48db-9c60-7fadc4c596cb
- 56ca7448-1a54-4d6e-b7ff-7ef11d53fa3c

Departments:
- 7c36b423-7396-4cb7-88ff-1a097e68e35f
- c364c85c-2e06-4c92-8f77-6ff9f8d8c2b8

These IDs are seeded automatically during backend startup for easier UI testing.

🧪 Testing

Backend:

Navigate to server/HikruCodeChallenge.Tests

Run dotnet test

Frontend:

Navigate to client

Run npm run test

All tests should pass without warnings.

📋 Notes

Seed data is initialized at startup for testing purposes.

Full CRUD is supported for Positions.

Only happy path is covered for simplicity, but extensible.

Project uses the latest Angular 19 best practices for standalone applications.

API and Frontend were developed considering clean, scalable architecture.