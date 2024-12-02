# Blazor Password Manager

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Setup](#setup)
- [Usage](#usage)
- [Folder Structure](#folder-structure)
- [Future Enhancements](#future-enhancements)

---

## Introduction

Blazor Password Manager is . The project includes both a **Blazor frontend** and an **ASP.NET Core Web API backend**, using SQLite as the database.

---

## Features

- **User Authentication**: Log in, log out, and manage sessions.
- **Password Management**: Store, retrieve, and manage application-specific credentials.
- **Account Management**: Change username, update passwords, and delete accounts.
- **Responsive Design**: Optimized for different screen sizes.

---

## Technologies

- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core Web API
- **Database**: SQLite
- **Other Libraries**:
  - [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage)

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- A modern web browser (e.g., Chrome, Edge, or Firefox)

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/Yetalon/finalproject.git
   cd finalproject
2. Set up the backend:

Navigate to the backend folder (e.g., Backend).
Run the following command to start the API:
  ```bash
  dotnet run
-The API will run on http://localhost:5000 by default.
-Set up the frontend:

Navigate to the frontend folder (e.g., Frontend).
Run the following command to start the Blazor app:
bash
Copy code
dotnet run
The application will be available at http://localhost:5001.
⚠️ Note: Ensure both the backend and frontend are running simultaneously on their respective localhost ports.

Usage
Open your browser and navigate to the Blazor WebAssembly app at http://localhost:5001.
Use the login form to authenticate and manage your account.
Explore the following functionalities:
Dashboard: Manage application credentials.
Settings: Update account details or delete your profile.
Logout: End the session.
Folder Structure
bash
Copy code
Blazor-User-Management-System/
├── Backend/               # ASP.NET Core Web API
│   ├── Controllers/       # API Controllers
│   ├── Models/            # Database Models
│   ├── Services/          # Business Logic Services
│   └── Program.cs         # Application Entry Point
├── Frontend/              # Blazor WebAssembly
│   ├── Pages/             # Blazor Pages
│   ├── Services/          # API Consumption Services
│   └── Program.cs         # Blazor App Entry Point
└── README.md              # Project Documentation
Future Enhancements
Deploy both frontend and backend to a shared hosting environment.
Implement encryption for stored passwords.
Introduce role-based access control (e.g., admin vs regular users).
Add integration tests for improved reliability.
Enhance UI with advanced styling frameworks.
