FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CleanCQRS.Web/CleanCQRS.Web.csproj", "src/CleanCQRS.Web/"]
RUN dotnet restore "src/CleanCQRS.Web/CleanCQRS.Web.csproj"
COPY . .
WORKDIR "/src/src/CleanCQRS.Web"
RUN dotnet build "CleanCQRS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCQRS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanCQRS.Web.dll"]
