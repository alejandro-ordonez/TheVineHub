# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ARG API_URL
ENV API_URL=$API_URL
USER app
WORKDIR /app

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG API_URL
ENV API_URL=$API_URL
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["JMMinistry.Web/JMMinistry.Web.csproj", "JMMinistry.Web/"]
RUN dotnet restore "./JMMinistry.Web/JMMinistry.Web.csproj"
COPY . .
WORKDIR "/src/JMMinistry.Web"
RUN dotnet build "./JMMinistry.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG API_URL
ENV API_URL=$API_URL
ARG BUILD_CONFIGURATION=Release
RUN sed -i "s|__SERVER_HOST__|${API_URL}|g" ./wwwroot/appsettings.json
RUN dotnet publish "./JMMinistry.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM nginx:alpine AS final
RUN mkdir /var/www
RUN mkdir /var/www/web
WORKDIR /var/www/web
#Copy from Environment(build/publish)
COPY --from=publish /app/publish/wwwroot .
RUN chmod 755 -R .
COPY JMMinistry.Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80