FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.API/ReadingIsGood.API.csproj", "ReadingIsGood.API/"]
RUN dotnet restore "ReadingIsGood.API/ReadingIsGood.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.API"
RUN dotnet build "ReadingIsGood.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingIsGood.API.dll"]
