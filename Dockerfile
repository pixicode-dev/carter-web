FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE  80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY [".", "."]
RUN dotnet restore "./CARTER.App/CARTER.App.csproj"
COPY . ./
WORKDIR /src/CARTER.App
RUN dotnet build "CARTER.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CARTER.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY ["CARTER.App/CARTER.App.xml", "."]
COPY ["CARTER.App/runtimeconfig.template.json", "."]
COPY ["CARTER.App/MailTemplates/", "."]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CARTER.App.dll", "--server.urls", "http://+:80;https://+:443"]
