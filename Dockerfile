# Use the official .NET SDK image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the solution file and restore NuGet packages
COPY *.sln .
COPY WebApp/*.csproj ./WebApp/
COPY Api/*.csproj ./Api/
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the solution
RUN dotnet build -c Release --no-restore

# Run tests (if any)
# RUN dotnet test

# Publish the projects
RUN dotnet publish WebApp/WebApp.csproj -c Release -o /app/publish/WebApp
RUN dotnet publish Api/Api.csproj -c Release -o /app/publish/Api

# Final stage: create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]