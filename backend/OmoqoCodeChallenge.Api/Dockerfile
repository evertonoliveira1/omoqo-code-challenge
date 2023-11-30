#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OmoqoCodeChallenge.Api/OmoqoCodeChallenge.Api.csproj", "OmoqoCodeChallenge.Api/"]
COPY ["OmoqoCodeChallenge.Application/OmoqoCodeChallenge.Application.csproj", "OmoqoCodeChallenge.Application/"]
COPY ["OmoqoCodeChallenge.Domain/OmoqoCodeChallenge.Domain.csproj", "OmoqoCodeChallenge.Domain/"]
COPY ["OmoqoCodeChallenge.Infrastructure/OmoqoCodeChallenge.Infrastructure.csproj", "OmoqoCodeChallenge.Infrastructure/"]
RUN dotnet restore "./OmoqoCodeChallenge.Api/./OmoqoCodeChallenge.Api.csproj"
COPY . .
WORKDIR "/src/OmoqoCodeChallenge.Api"
RUN dotnet build "./OmoqoCodeChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OmoqoCodeChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OmoqoCodeChallenge.Api.dll"]