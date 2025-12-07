FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdventOfCode2025/AdventOfCode2025.csproj", "AdventOfCode2025/"]
RUN dotnet restore "AdventOfCode2025/AdventOfCode2025.csproj"
COPY . .
WORKDIR "/src/AdventOfCode2025"
RUN dotnet build "./AdventOfCode2025.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AdventOfCode2025.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventOfCode2025.dll"]
