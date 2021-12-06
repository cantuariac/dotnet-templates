#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/Example.Api/Example.Api.csproj", "src/services/Example.Api/"]
COPY ["src/core/Core.Business/Core.Business.csproj", "src/core/Core.Business/"]
COPY ["src/core/Core.Api/Core.Api.csproj", "src/core/Core.Api/"]
COPY ["src/core/Core.Data/Core.Data.csproj", "src/core/Core.Data/"]
RUN dotnet restore "src/services/Example.Api/Example.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Example.Api"
RUN dotnet build "Example.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Api.dll"]