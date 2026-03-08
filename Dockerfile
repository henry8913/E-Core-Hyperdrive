# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# Copy project file and restore as distinct layers
COPY *.sln .
COPY ECoreHyperdrive/*.csproj ./ECoreHyperdrive/
COPY ECoreHyperdrive.Client/*.csproj ./ECoreHyperdrive.Client/
RUN dotnet restore

# Copy source code and publish app
COPY ECoreHyperdrive/. ./ECoreHyperdrive/
COPY ECoreHyperdrive.Client/. ./ECoreHyperdrive.Client/
WORKDIR /source/ECoreHyperdrive
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENTRYPOINT ["dotnet", "ECoreHyperdrive.dll"]
