#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["e-Commerce.API/e-Commerce.API.csproj", "e-Commerce.API/"]
COPY ["e-Commerce.Servico/e-Commerce.Servico.csproj", "e-Commerce.Servico/"]
COPY ["e-Commerce.Infra/e-Commerce.Infra.csproj", "e-Commerce.Infra/"]
COPY ["e-Commerce.Dominio/e-Commerce.Dominio.csproj", "e-Commerce.Dominio/"]
RUN dotnet restore "e-Commerce.API/e-Commerce.API.csproj"
COPY . .
WORKDIR "/src/e-Commerce.API"
RUN dotnet build "e-Commerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "e-Commerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "e-Commerce.API.dll"]