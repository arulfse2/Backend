#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["COVID19Tracker.User/COVID19Tracker.User.csproj", "COVID19Tracker.User/"]
RUN dotnet restore "COVID19Tracker.User/COVID19Tracker.User.csproj"
COPY . .
WORKDIR "/src/COVID19Tracker.User"
RUN dotnet build "COVID19Tracker.User.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "COVID19Tracker.User.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "COVID19Tracker.User.dll"]