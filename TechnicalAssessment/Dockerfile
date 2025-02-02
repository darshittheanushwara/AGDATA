# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the solution file and the project files
COPY *.sln .
COPY TechnicalAssessment.API/TechnicalAssessment.API.csproj TechnicalAssessment.API/
COPY TechnicalAssessment.Application/TechnicalAssessment.Application.csproj TechnicalAssessment.Application/
COPY TechnicalAssessment.Core/TechnicalAssessment.Core.csproj TechnicalAssessment.Core/
COPY TechnicalAssessment.Domain/TechnicalAssessment.Domain.csproj TechnicalAssessment.Domain/
COPY TechnicalAssessment.Infrastructure/TechnicalAssessment.Infrastructure.csproj TechnicalAssessment.Infrastructure/
COPY TechnicalAssessment.IoC/TechnicalAssessment.IoC.csproj TechnicalAssessment.IoC/

# Restore all NuGet packages
RUN dotnet restore TechnicalAssessment.API/TechnicalAssessment.API.csproj

# Copy all the other files
COPY . .

# Build the project
WORKDIR /src/TechnicalAssessment.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Build a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose both HTTP and HTTPS ports
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "TechnicalAssessment.API.dll"]