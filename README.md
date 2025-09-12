# ASP.NET Web API

A modern ASP.NET Core 8.0 Web API project with built-in Swagger/OpenAPI documentation and weather forecast endpoints.

## Features

- **ASP.NET Core 8.0**: Latest .NET framework with minimal APIs
- **Swagger/OpenAPI Integration**: Interactive API documentation and testing
- **Weather Forecast API**: Sample endpoint demonstrating REST API functionality
- **Development Environment Support**: Configured for local development with HTTPS
- **JSON Serialization**: Built-in JSON response formatting

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

### Running the Application

1. Navigate to the project directory:
   ```bash
   cd AspNetWebApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open your browser and navigate to:
   - **Swagger UI**: `http://localhost:5170/swagger` or `https://localhost:7299/swagger`
   - **API Endpoint**: `http://localhost:5170/weatherforecast` or `https://localhost:7299/weatherforecast`

## API Endpoints

### Weather Forecast

- **GET** `/weatherforecast`
  - Returns a collection of weather forecast data for the next 5 days
  - Response format: JSON array of weather forecast objects
  - Each object contains:
    - `date`: Date of the forecast (ISO 8601 format)
    - `temperatureC`: Temperature in Celsius
    - `temperatureF`: Temperature in Fahrenheit (auto-calculated)
    - `summary`: Weather description

#### Example Response

```json
[
  {
    "date": "2025-09-13",
    "temperatureC": 43,
    "summary": "Hot",
    "temperatureF": 109
  },
  {
    "date": "2025-09-14", 
    "temperatureC": 42,
    "summary": "Chilly",
    "temperatureF": 107
  }
]
```

## Project Structure

```
AspNetWebApi/
├── AspNetWebApi.csproj          # Project file with dependencies
├── Program.cs                   # Application entry point and configuration
├── appsettings.json            # Application configuration
├── appsettings.Development.json # Development-specific settings
├── AspNetWebApi.http           # HTTP test requests
└── Properties/
    └── launchSettings.json     # Development server settings
```

## Testing the API

### Using Swagger UI

1. Run the application
2. Navigate to `http://localhost:5170/swagger`
3. Click on the GET `/weatherforecast` endpoint
4. Click "Try it out"
5. Click "Execute"

### Using curl

```bash
curl -X GET "http://localhost:5170/weatherforecast" -H "accept: application/json"
```

### Using the included HTTP file

Open `AspNetWebApi.http` in your favorite REST client or IDE (like Visual Studio/VS Code with REST Client extension).

## Development

### Adding New Endpoints

To add new API endpoints, modify the `Program.cs` file and add new `app.MapGet()`, `app.MapPost()`, or other HTTP verb methods.

### Configuration

- **Development**: Settings in `appsettings.Development.json`
- **Production**: Settings in `appsettings.json`
- **Launch Profiles**: Configure in `Properties/launchSettings.json`

## Technologies Used

- **ASP.NET Core 8.0**: Web framework
- **Swagger/OpenAPI**: API documentation (Swashbuckle.AspNetCore)
- **Minimal APIs**: Simplified endpoint definition
- **Kestrel**: Built-in web server
- **JSON**: Serialization and response format

## License

This project is created for demonstration purposes.
