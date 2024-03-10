#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./WebApps/KonsiCred.Web/KonsiCred.Web/KonsiCred.Web.csproj", "WebApps/KonsiCred.Web/KonsiCred.Web/"]
COPY ["./Services/Konsi/KonsiCred.Application/KonsiCred.Application.csproj", "Services/Konsi/KonsiCred.Application/"]
COPY ["./WebApps/KonsiCred.Web/KonsiCred.Web.Client/KonsiCred.Web.Client.csproj", "WebApps/KonsiCred.Web/KonsiCred.Web.Client/"]
RUN dotnet restore "WebApps/KonsiCred.Web/KonsiCred.Web"
COPY . .
WORKDIR "WebApps/KonsiCred.Web/KonsiCred.Web"
RUN dotnet build "KonsiCred.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KonsiCred.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KonsiCred.Web.dll"]