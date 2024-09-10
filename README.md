# CustomerManager

A simple customer management application built using .NET Core 8 with a clean architecture design. This project leverages CQRS with MediatR, Fluent Validation, Entity Framework Core (InMemory database), and includes exception handling middleware. The application is seeded with an initial set of 20 customers.

## Technologies

- **.NET Core 8**
- **CQRS** with **MediatR**
- **Fluent Validation** for request validation  
- **Entity Framework Core** with **InMemory Database** for persistence
- **Exception Handler Middleware** for centralized exception handling
- **Swagger** for API documentation (Swashbuckle.AspNetCore)
- **Initial Data Seeding** of 20 customers

## Project Structure (Clean Architecture)

```bash
CustomerManager/
├── CustomerManager.API/            # API layer (controllers, middlewares, configurations)
├── CustomerManager.Application/    # Application layer (commands, queries, validators)
├── CustomerManager.Core/           # Core layer (entities, base domain models)
├── CustomerManager.Infrastructure/ # Infrastructure layer (EF configurations, persistence)
```

## Getting Started

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (Optional)

### Steps to Build and Run the Project

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-repo/customer-manager.git
   cd customer-manager
   ```

2. **Open in Visual Studio**:
   Open the `CustomerManager.sln` solution file using Visual Studio 2022 or above.

3. **Restore Dependencies**:
   Run the following command in the terminal to restore all the required NuGet packages:
   ```bash
   dotnet restore
   ```

4. **Run the Application**:
   You can run the project directly from Visual Studio by pressing `F5`, or using the terminal:
   ```bash
   dotnet run --project CustomerManager.API
   ```

5. **Access the API**:
   Navigate to `http://localhost:5000/swagger` to explore the available endpoints via Swagger UI.

### Initial Data

- The application seeds an initial set of 20 customers into the in-memory database, available upon startup.
