# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
# Set the working directory for our app
WORKDIR /src
# Copy the .csproj file and restore dependencies
COPY "./JMMinistry.Web/JMMinistry.Web.csproj" "JMMinistry.Web/"
RUN dotnet restore "./JMMinistry.Web/JMMinistry.Web.csproj"
# Copy all contents from the main project folder and build the app
COPY . .
WORKDIR "/src/JMMinistry.Web"
RUN dotnet build "./JMMinistry.Web.csproj" -c Release -o /build

# Publish the project to the publish folder
FROM build-env AS publish
RUN dotnet publish "./JMMinistry.Web.csproj" -c Release -o /publish

# Use the base Nginx image
FROM nginx:alpine AS final
# Set the working directory for Nginx
WORKDIR /usr/share/nginx/html
# Copy the contents from the publish folder into Nginx's html folder
COPY --from=publish /publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
