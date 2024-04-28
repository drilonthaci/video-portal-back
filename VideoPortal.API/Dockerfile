# Use the official ASP.NET Core SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use a lightweight ASP.NET Core runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80

# Copy the built application from the build stage
COPY --from=build-env /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "VideoPortal.API.dll"]