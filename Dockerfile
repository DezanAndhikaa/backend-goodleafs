FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /Src
COPY Api/Api.csproj Src/Api/
COPY Persistence/Persistence.csproj Src/Persistence/
COPY Application/Application.csproj Src/Application/
COPY Domain/Domain.csproj Src/Domain/

RUN dotnet restore "Src/Api/Api.csproj"
COPY . .

WORKDIR /Src/Api
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll" ,"--urls", "http://*:5000"]

