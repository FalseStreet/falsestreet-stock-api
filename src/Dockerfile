# Base image for the runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy .csproj files
COPY stock-api/stock-api.csproj stock-api/
COPY stock-core/stock-core.csproj stock-core/
COPY stock-infra/stock-infra.csproj stock-infra/

# Restore
RUN dotnet restore "stock-api/stock-api.csproj"

# Copy the rest of the source
COPY . .

# Build
WORKDIR /src/stock-api
RUN dotnet build "stock-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "stock-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "stock-api.dll"]
