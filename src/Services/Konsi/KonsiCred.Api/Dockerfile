FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Services/Konsi/KonsiCred.Api/KonsiCred.Api.csproj", "Services/Konsi/KonsiCred.Api/"]
COPY ["./Core/Konsi.Core/KonsiCred.Core.csproj", "Core/Konsi.Core/"]
COPY ["./Facade/Konsi.Facade/KonsiCred.Facade.csproj", "Facade/Konsi.Facade/"]
COPY ["./Services/Konsi/KonsiCred.Application/KonsiCred.Application.csproj", "Services/Konsi/KonsiCred.Application/"]

RUN dotnet restore "Services/Konsi/KonsiCred.Api/"
COPY . .
WORKDIR "Services/Konsi/KonsiCred.Api"
RUN dotnet build "KonsiCred.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KonsiCred.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KonsiCred.Api.dll"]