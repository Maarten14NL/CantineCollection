#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CollectionAdmin/CollectionAdmin.csproj", "CollectionAdmin/"]
RUN dotnet restore "CollectionAdmin/CollectionAdmin.csproj"
COPY . .
WORKDIR "/src/CollectionAdmin"
RUN dotnet build "CollectionAdmin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectionAdmin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionAdmin.dll"]