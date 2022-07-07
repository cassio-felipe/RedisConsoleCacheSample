FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RedisConsoleCacheSample.csproj", "./"]
RUN dotnet restore "RedisConsoleCacheSample.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RedisConsoleCacheSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisConsoleCacheSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisConsoleCacheSample.dll"]
