# Blazor Password Manager

Blazor Password Manager is a project I created for my final project in **CSCI 1260**. The password manager allows users generate random passphrases from a list of 20,000 words and to store their information for different applications. The apps can be edited and deleted from the dashboard. The user can also customize their login with changing their username, password, and delete their account. The app also takes use of bootstrap 5 to provide a responsive design for different screen sizes.


## Stack

- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core Web API
- **Database**: SQLite
- **Other Libraries**:
  - [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage)


## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or later)
- A modern web browser

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/Yetalon/finalproject.git
   cd finalproject
   ```
2. Set up the backend:

- Navigate to the backend folder (e.g., aspbackend).
- Run the following command to start the API:
  ```bash
  dotnet watch run
  ```
- The API will run on http://localhost:5218 by default. ⚠️(you should not change this)

3. Set up the frontend:

- Navigate to the frontend folder (e.g., passfrontend).
- Run the following command to start the Blazor app:
  ```bash
  dotnet watch run
  ```
After running you should get an output similar to this. It should also open the webpage in a browser automatically.
  ```bash
  dotnet watch 🚀 Started
  info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5058
  ```
The application will be available at http://localhost:****. (replace with your port for the frontend)
⚠️ Note: Ensure both the backend and frontend are running simultaneously on their respective localhost ports. (these should be running in two seperate terminals)


## Usage
1. Open your browser and navigate to the Blazor app at http://localhost:****. (replace with your port)
2. Create a new login on the login page
3. Explore the following functionalities:
   - **Dashboard**: Manage application.
   - **Applications**: Create new applications with unique passphrases.
   - **Settings**: Update account details or delete your account.
   - **Logout**: End the session.


## Folder Structure
  ```bash
    FinalProject/
    ├── aspbackend/            # ASP.NET Core Web API
    │   ├── Controllers/       # API Controllers
    │   ├── Models/            # Database Models
    │   └── Program.cs         # Application Entry Point
    ├── passfrontend/          # Blazor WebAssembly
    │   ├── Pages/             # Blazor Pages
    │   ├── Services/          # API, User, and Passphrase services
    │   └── Program.cs         # Blazor App Entry Point
    └── README.md              # Project Documentation
  ```


## Future Enhancements
- Deploy both frontend and backend to a shared hosting environment.
- Implement encryption for stored passwords.
- Introduce role-based access control (admin vs regular users).
- Add integration tests for improved reliability.
- Enhance UI.
