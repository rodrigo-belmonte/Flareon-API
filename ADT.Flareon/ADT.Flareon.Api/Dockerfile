#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ADT.Flareon.Api/ADT.Flareon.Api.csproj", "ADT.Flareon.Api/"]
RUN dotnet restore "ADT.Flareon.Api/ADT.Flareon.Api.csproj"
COPY . .
WORKDIR "/src/ADT.Flareon.Api"
RUN dotnet build "ADT.Flareon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ADT.Flareon.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ADT.Flareon.Api.dll"]