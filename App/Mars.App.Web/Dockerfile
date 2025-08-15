# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code and publish the app
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Start the app
ENTRYPOINT ["dotnet", "Mars.App.Web.dll"]
