FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RetailPlatform.API/RetailPlatform.API.csproj", "RetailPlatform.API/"]
COPY ["RetailPlatform.Common/RetailPlatform.Common.csproj", "RetailPlatform.Common/"]
COPY ["RetailPlatform.Core/RetailPlatform.Core.csproj", "RetailPlatform.Core/"]
COPY ["RetailPlatform.Infrastructure/RetailPlatform.Infrastructure.csproj", "RetailPlatform.Infrastructure/"]
RUN dotnet restore "RetailPlatform.API/RetailPlatform.API.csproj"
COPY . .
WORKDIR "/src/RetailPlatform.API"
RUN dotnet build "RetailPlatform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetailPlatform.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "RetailPlatform.API.dll"]