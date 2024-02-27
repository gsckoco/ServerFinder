FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ServerFinder/ServerFinder.csproj", "ServerFinder/"]
RUN dotnet restore "ServerFinder/ServerFinder.csproj"
COPY . .
WORKDIR "/src/ServerFinder"
RUN dotnet build "ServerFinder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerFinder.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerFinder.dll"]
