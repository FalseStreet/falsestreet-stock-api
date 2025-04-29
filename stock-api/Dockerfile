# Use ASP.NET Core runtime image for final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 10000

# Use SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all .csproj files
COPY ../stock-core/stock-core.csproj ./stock-core/
COPY ../stock-infra/stock-infra.csproj ./stock-infra/
COPY . stock-api.csproj .
# Restore all projects
RUN dotnet restore ./stock-api/stock-api.csproj

# Copy full source code
COPY ../stock-core/ ./stock-core/
COPY ../stock-infra/ ./stock-infra/
COPY . .

WORKDIR /src/stock-api
RUN dotnet build "stock-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/stock-api
RUN dotnet publish "stock-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "stock-api.dll"]
