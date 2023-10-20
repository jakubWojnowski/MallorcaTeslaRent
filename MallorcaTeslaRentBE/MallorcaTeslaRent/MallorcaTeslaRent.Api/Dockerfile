# Stage 1: Build the .NET Core application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MallorcaTeslaRentBE.csproj", "./"]
RUN dotnet restore "MallorcaTeslaRentBE.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "MallorcaTeslaRentBE.csproj" -c Release -o /app/build

# Stage 2: Publish the .NET Core application
FROM build AS publish
RUN dotnet publish "MallorcaTeslaRentBE.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Build the MSSQL image
FROM mcr.microsoft.com/mssql/server:2019-latest AS sql
ENV SA_PASSWORD=YourStrongPassword
ENV ACCEPT_EULA=Y
WORKDIR /app

# Add your SQL scripts, if any
COPY ./sql-scripts/ /app

# You can also execute SQL scripts if needed
# RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrongPassword -d master -i /app/your-script.sql

# Stage 4: Create the final image with the .NET Core app and MSSQL
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=sql /app /var/opt/mssql/data

ENTRYPOINT ["dotnet", "MallorcaTeslaRentBE.dll"]
