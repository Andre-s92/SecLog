#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecLog.API/SecLog.API.csproj", "SecLog.API/"]
COPY ["SecLog.Application/SecLog.Application.csproj", "SecLog.Application/"]
COPY ["SecLog.Domain/SecLog.Domain.csproj", "SecLog.Domain/"]
COPY ["SecLog.Data/SecLog.Data.csproj", "SecLog.Data/"]
RUN dotnet restore "SecLog.API/SecLog.API.csproj"
COPY . .
WORKDIR "/src/SecLog.API"
RUN dotnet build "SecLog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecLog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecLog.API.dll"]