# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /Blogger
COPY . .
RUN dotnet restore "./WebAPI/WebAPI.csproj" --disable-parallel
RUN dotnet publish "./WebAPI/WebAPI.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT["dotnet","WebAPI.dll"]