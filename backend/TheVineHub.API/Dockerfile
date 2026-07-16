FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["backend/TheVineHub.API/TheVineHub.API.csproj", "backend/TheVineHub.API/"]
RUN dotnet restore "backend/TheVineHub.API/TheVineHub.API.csproj"
COPY . .
WORKDIR "/src/backend/TheVineHub.API"
RUN dotnet build "TheVineHub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheVineHub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheVineHub.API.dll"]
