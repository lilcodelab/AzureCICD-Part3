# Stage 1: Build the Angular app (AzureCICDUI)
FROM node:18 AS angular-build
WORKDIR /app
COPY AzureCICDUI/package*.json ./
RUN npm install
COPY AzureCICDUI/ .
# Build the Angular application for production
RUN npm run build --prod

# Stage 2: Build the ASP.NET app (AzureCICD)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS aspnet-build
WORKDIR /src

# Copy the Infrastructure project files and restore them
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore Infrastructure/Infrastructure.csproj

# Copy the Core project files and restore them
# It will also restore Infrastructure again since Core depends on it
COPY Core/Core.csproj Core/
RUN dotnet restore Core/Core.csproj

# Now copy the rest of the Core and Infrastructure project files
COPY Infrastructure/ Infrastructure/
COPY Core/ Core/

# Copy the main AzureCICD project file and restore
COPY AzureCICD/AzureCICD.csproj .
RUN dotnet restore

# Now copy the rest of the AzureCICD project files and publish
COPY AzureCICD/ .
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Build the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=aspnet-build /app/publish .
# Copy the Angular build output from the 'dist/azure-cicdui' directory to 'wwwroot'
COPY --from=angular-build /app/dist/azure-cicdui ./wwwroot
ENTRYPOINT ["dotnet", "AzureCICD.dll"]
