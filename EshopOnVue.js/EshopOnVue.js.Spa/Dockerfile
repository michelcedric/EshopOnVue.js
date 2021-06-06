#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update -y
RUN apt-get install curl gnupg -y
RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EshopOnVue.js.Spa/EshopOnVue.js.Spa.csproj", "EshopOnVue.js.Spa/"]
RUN dotnet restore "EshopOnVue.js.Spa/EshopOnVue.js.Spa.csproj"
COPY . .
WORKDIR "/src/EshopOnVue.js.Spa"
RUN dotnet build "EshopOnVue.js.Spa.csproj" -c Release -o /app/build

RUN apt-get update -y
RUN apt-get install curl gnupg -y
RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs

FROM build AS publish
RUN dotnet publish "EshopOnVue.js.Spa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EshopOnVue.js.Spa.dll"]