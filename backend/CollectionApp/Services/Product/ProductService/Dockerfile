#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Product/ProductService/ProductService.csproj", "Services/Product/ProductService/"]
COPY ["Services/Product/ProductLogic/ProductLogic.csproj", "Services/Product/ProductLogic/"]
COPY ["Services/Product/ProductEntities/ProductEntities.csproj", "Services/Product/ProductEntities/"]
COPY ["Services/Product/ProductFactory/ProductFactory.csproj", "Services/Product/ProductFactory/"]
COPY ["Services/Product/ProductData/ProductData.csproj", "Services/Product/ProductData/"]
RUN dotnet restore "Services/Product/ProductService/ProductService.csproj"
COPY . .
WORKDIR "/src/Services/Product/ProductService"
RUN dotnet build "ProductService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.dll"]
