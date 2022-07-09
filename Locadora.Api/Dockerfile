#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Locadora.Api/Locadora.Api.csproj", "Locadora.Api/"]
COPY ["Locadora.Infra.IoC/Locadora.Infra.IoC.csproj", "Locadora.Infra.IoC/"]
COPY ["Locadora.Application/Locadora.Application.csproj", "Locadora.Application/"]
COPY ["Locadora.Domain/Locadora.Domain.csproj", "Locadora.Domain/"]
COPY ["Locadora.Infra.Data/Locadora.Infra.Data.csproj", "Locadora.Infra.Data/"]
RUN dotnet restore "Locadora.Api/Locadora.Api.csproj"
COPY . .
WORKDIR "/src/Locadora.Api"
RUN dotnet build "Locadora.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locadora.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locadora.Api.dll"]