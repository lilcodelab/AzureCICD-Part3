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
COPY AzureCICD/AzureCICD.csproj .
RUN dotnet restore
COPY AzureCICD/ .
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Build the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=aspnet-build /app/publish .
# Copy the Angular build output from the 'dist/azure-cicdui' directory to 'wwwroot'
COPY --from=angular-build /app/dist/azure-cicdui ./wwwroot
ENTRYPOINT ["dotnet", "AzureCICD.dll"]
