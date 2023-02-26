FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CleanCQRS.API/CleanCQRS.API.csproj", "CleanCQRS.API/"]
RUN dotnet restore "CleanCQRS.API/CleanCQRS.API.csproj"
COPY . .
WORKDIR "/src/CleanCQRS.API"
RUN dotnet build "CleanCQRS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCQRS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanCQRS.API.dll"]
