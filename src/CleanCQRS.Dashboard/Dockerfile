FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CleanCQRS.Dashboard/CleanCQRS.Dashboard.csproj", "src/CleanCQRS.Dashboard/"]
RUN dotnet restore "src/CleanCQRS.Dashboard/CleanCQRS.Dashboard.csproj"
COPY . .
WORKDIR "/src/src/CleanCQRS.Dashboard"
RUN dotnet build "CleanCQRS.Dashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCQRS.Dashboard.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY src/CleanCQRS.Dashboard/nginx.conf /etc/nginx/nginx.conf