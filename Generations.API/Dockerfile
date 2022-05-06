#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Generations.API/Generations.API.csproj", "Generations.API/"]
RUN dotnet restore "Generations.API/Generations.API.csproj"
COPY . .
WORKDIR "/src/Generations.API"
RUN dotnet build "Generations.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Generations.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Generations.API.dll"]