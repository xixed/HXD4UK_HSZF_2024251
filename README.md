# HXD4UK_HSZF_2024251

A multi-layered C# application with application logic, data models, persistence layer, and comprehensive testing.

## Project Overview

HXD4UK_HSZF_2024251 is a structured .NET solution following clean architecture principles. The project is organized into multiple layers, each with specific responsibilities, ensuring maintainability, scalability, and testability. The repository name includes the Neptun code (HXD4UK) and academic period identifier, suggesting this is an academic project or assignment.

## Technology Stack

- **Language**: C# (100%)
- **Architecture Pattern**: Layered/Clean Architecture
- **Database**: Microsoft SQL Server
- **Testing Framework**: Included test project for unit and integration testing

## Project Structure

```
HXD4UK_HSZF_2024251/
├── HXD4UK_HSZF_2024251/                    # Main application entry point
├── HXD4UK_HSZF_20242501.Application/       # Application services and business logic
├── HXD4UK_HSZF_20242501.Model/             # Data models and entities
├── HXD4UK_HSZF_20242501.Persistence.MsSql/ # Data access layer (SQL Server)
├── HXD4UK_HSZF_20242501.Test/              # Unit and integration tests
├── HXD4UK_HSZF_2024251.sln                 # Visual Studio solution file
├── .gitattributes                          # Git attributes configuration
└── .gitignore                              # Git ignore rules
```

### Layer Descriptions

#### Main Application (`HXD4UK_HSZF_2024251`)
The entry point of the application, containing:
- Application startup logic
- Dependency injection configuration
- Main application flow

#### Application Layer (`HXD4UK_HSZF_20242501.Application`)
Contains business logic and application services:
- Use cases and services
- Business rule implementations
- Application workflows
- Service interfaces

#### Model Layer (`HXD4UK_HSZF_20242501.Model`)
Defines data structures and domain models:
- Entity classes
- Value objects
- Data Transfer Objects (DTOs)
- Domain models representing business concepts

#### Persistence Layer (`HXD4UK_HSZF_20242501.Persistence.MsSql`)
Data access and database operations:
- Repository pattern implementation
- Database context and configuration
- SQL Server connection management
- CRUD operations
- Database migrations (if using Entity Framework)

#### Test Layer (`HXD4UK_HSZF_20242501.Test`)
Automated testing:
- Unit tests
- Integration tests
- Test fixtures and mocks
- Test data setup

## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download) or [.NET Core/.NET 5+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Developer Edition or Express)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/xixed/HXD4UK_HSZF_2024251.git
   cd HXD4UK_HSZF_2024251
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure the database**:
   - Update connection strings in configuration files if needed
   - Apply database migrations (if using Entity Framework):
     ```bash
     dotnet ef database update
     ```

4. **Build the solution**:
   ```bash
   dotnet build
   ```

### Running the Application

```bash
# Navigate to the main application directory
cd HXD4UK_HSZF_2024251

# Run the application
dotnet run
```

### Running Tests

```bash
# Run all tests in the solution
dotnet test

# Run tests with verbose output
dotnet test --verbosity detailed

# Run specific test project
dotnet test HXD4UK_HSZF_20242501.Test
```

## Architecture & Design Patterns

### Clean Architecture Principles

This project follows clean architecture by:
- **Separation of Concerns**: Each layer has a specific responsibility
- **Dependency Inversion**: High-level modules don't depend on low-level modules
- **Testability**: Each layer can be tested independently
- **Maintainability**: Clear structure makes code easier to understand and modify

### Layer Dependencies

```
┌─────────────────────────────────────────┐
│  HXD4UK_HSZF_2024251 (Main App)         │ (Entry Point)
└────────────────┬────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────┐
│  HXD4UK_HSZF_20242501.Application       │ (Business Logic)
└────────────────┬────────────────────────┘
                 │
        ┌────────┴────────┐
        ▼                 ▼
┌──────────────────┐  ┌──────────────────────┐
│ Model            │  │ Persistence.MsSql    │
│ (Entities/DTOs)  │  │ (Data Access)        │
└──────────────────┘  └──────────────────────┘
```

## Database

The project uses **Microsoft SQL Server** for data persistence:
- Database models are defined in the Model layer
- Data access is handled through the Persistence.MsSql layer
- Connection management and migrations are configured for SQL Server

### Setting Up SQL Server

1. Install SQL Server (Developer Edition recommended for development)
2. Create a database for the project
3. Update the connection string in configuration
4. Run migrations to create tables and schemas

## Development Workflow

### Adding New Features

1. Define entity in `Model` layer
2. Add repository/data access in `Persistence.MsSql` layer
3. Implement business logic in `Application` layer
4. Add corresponding tests in `Test` layer
5. Update main application as needed

### Code Organization Best Practices

- Keep models simple and focused on data
- Place business logic in Application services
- Use dependency injection for loose coupling
- Write tests for all public business logic
- Follow naming conventions consistent across layers

## Building & Deployment

### Debug Build
```bash
dotnet build --configuration Debug
```

### Release Build
```bash
dotnet build --configuration Release
```

### Publishing
```bash
dotnet publish --configuration Release
```

## Repository Information

- **Created**: November 3, 2024
- **Last Updated**: Recently
- **Default Branch**: master
- **Language**: 100% C#
- **License**: Not specified

## Testing

The project includes a comprehensive test suite:

```bash
# Run all tests
dotnet test

# Run specific test class
dotnet test --filter "ClassName"

# Run tests with code coverage
dotnet test /p:CollectCoverage=true
```

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Make your changes
4. Add/update tests as needed
5. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
6. Push to the branch (`git push origin feature/AmazingFeature`)
7. Open a Pull Request

## Resources

- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Microsoft SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [GitHub Repository](https://github.com/xixed/HXD4UK_HSZF_2024251)

## Support

For issues, questions, or suggestions, please open an issue on the [GitHub Issues](https://github.com/xixed/HXD4UK_HSZF_2024251/issues) page.

## License

This project is publicly available on GitHub. See repository settings for license information.

---

Built with C# and SQL Server following clean architecture principles.
