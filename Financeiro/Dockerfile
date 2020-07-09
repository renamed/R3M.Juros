FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Domain/Domain.csproj Domain/Domain.csproj
COPY ExternalServices/ExternalServices.csproj ExternalServices/ExternalServices.csproj
COPY Services/Services.csproj Services/Services.csproj
COPY WebApi/WebApi.csproj WebApi/WebApi.csproj

RUN dotnet restore WebApi/WebApi.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out WebApi/WebApi.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApi.dll"]