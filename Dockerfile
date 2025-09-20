# This Dockerfile is an example if you want to build the API project root
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/Million.RealEstate.Api/Million.RealEstate.Api.csproj"
RUN dotnet publish "src/Million.RealEstate.Api/Million.RealEstate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Million.RealEstate.Api.dll"]
