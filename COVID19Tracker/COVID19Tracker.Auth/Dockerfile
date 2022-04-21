#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["COVID19Tracker.Auth/COVID19Tracker.Auth.csproj", "COVID19Tracker.Auth/"]
RUN dotnet restore "COVID19Tracker.Auth/COVID19Tracker.Auth.csproj"
COPY . .
WORKDIR "/src/COVID19Tracker.Auth"
RUN dotnet build "COVID19Tracker.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "COVID19Tracker.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "COVID19Tracker.Auth.dll"]