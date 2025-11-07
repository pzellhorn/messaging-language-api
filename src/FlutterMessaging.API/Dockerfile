# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_HTTP_PORTS=8080
WORKDIR /app 
EXPOSE 8080
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
 
COPY ["FlutterMessagingApi.sln", "."]
COPY ["src/FlutterMessaging.API/FlutterMessaging.API.csproj", "src/FlutterMessaging.API/"]
COPY ["src/FlutterMessaging.ClientAPI/FlutterMessaging.ClientAPI.csproj", "src/FlutterMessaging.ClientAPI/"]
COPY ["src/FlutterMessaging.DTO/FlutterMessaging.DTO.csproj", "src/FlutterMessaging.DTO/"]
COPY ["src/FlutterMessaging.Logic/FlutterMessaging.Logic.csproj", "src/FlutterMessaging.Logic/"]
COPY ["src/FlutterMessaging.State/FlutterMessaging.State.csproj", "src/FlutterMessaging.State/"]
 
COPY ["Core/src/pzellhorn.Core.API/pzellhorn.Core.API.csproj", "Core/src/pzellhorn.Core.API/"]
COPY ["Core/src/pzellhorn.Core.ClientAPI/pzellhorn.Core.ClientAPI.csproj", "Core/src/pzellhorn.Core.ClientAPI/"]
COPY ["Core/src/pzellhorn.Core.Logic/pzellhorn.Core.Logic.csproj", "Core/src/pzellhorn.Core.Logic/"]
COPY ["Core/src/pzellhorn.Core.State/pzellhorn.Core.State.csproj", "Core/src/pzellhorn.Core.State/"]
 
RUN dotnet restore "src/FlutterMessaging.API/FlutterMessaging.API.csproj"

COPY . .
RUN dotnet build "src/FlutterMessaging.API/FlutterMessaging.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
 
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/FlutterMessaging.API/FlutterMessaging.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

RUN ls -la /app/publish
RUN test -f /app/publish/FlutterMessagingApi.dll || (echo "Publish output:" && ls -la /app/publish && exit 1)
 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlutterMessagingApi.dll"] 