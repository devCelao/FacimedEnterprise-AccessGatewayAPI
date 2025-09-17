# syntax=docker/dockerfile:1.7-labs

ARG DOTNET_VERSION=9.0
ARG BUILD_CONFIGURATION=Release
######## RUNTIME ########
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

######## BUILD ########
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS compilate
WORKDIR /src

COPY FacimedEnterprise.sln                                       ./
COPY Componentes/WebApiCore/WebApiCore.csproj                    Componentes/WebApiCore/

COPY Gateways/AccessGateway/AccessGatewayAPI/*.csproj               Gateways/AccessGateway/AccessGatewayAPI/
COPY Gateways/AccessGateway/AccessGatewayApplication/*.csproj       Gateways/AccessGateway/AccessGatewayApplication/

RUN dotnet restore Gateways/AccessGateway/AccessGatewayAPI/AccessGatewayAPI.csproj
COPY . .

WORKDIR /src/Gateways/AccessGateway/AccessGatewayAPI
RUN dotnet publish -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false


######## FINAL ########
FROM runtime AS final
WORKDIR /app
COPY --from=compilate /app/publish .
ENTRYPOINT ["dotnet", "AccessGatewayAPI.dll"]