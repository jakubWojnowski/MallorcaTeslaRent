ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS domain-build
WORKDIR /src/Domain
COPY ["MallorcaTeslaRentBE.Domain.csproj", "./"]
RUN dotnet restore "MallorcaTeslaRentBE.Domain.csproj"
COPY . .
WORKDIR "/src/Domain"
RUN dotnet build "MallorcaTeslaRentBE.Domain.csproj" -c Release -o /app/domain

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS infrastructure-build
WORKDIR /src/Infrastructure
COPY ["MallorcaTeslaRentBE.Infrastructure.csproj", "./"]
RUN dotnet restore "MallorcaTeslaRentBE.Infrastructure.csproj"
COPY . .
WORKDIR "/src/Infrastructure"
RUN dotnet build "MallorcaTeslaRentBE.Infrastructure.csproj" -c Release -o /app/infrastructure

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS application-build
WORKDIR /src/Application
COPY ["MallorcaTeslaRentBE.Application.csproj", "./"]
RUN dotnet restore "MallorcaTeslaRentBE.Application.csproj"
COPY . .
WORKDIR "/src/Application"
RUN dotnet build "MallorcaTeslaRentBE.Application.csproj" -c Release -o /app/application

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS api-build
WORKDIR /src/API
COPY ["MallorcaTeslaRentBE.Api.csproj", "./"]
RUN dotnet restore "MallorcaTeslaRentBE.Api.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "MallorcaTeslaRentBE.Api.csproj" -c Release -o /app/api

FROM api-build AS api-publish
RUN dotnet publish "MallorcaTeslaRentBE.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=api-publish /app/publish .
ENTRYPOINT ["dotnet", "MallorcaTeslaRentBE.Api.dll"]
