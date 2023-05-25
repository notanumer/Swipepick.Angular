FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Swipepick.Angular.Web/Swipepick.Angular.Web.csproj", "src/Swipepick.Angular.Web/"]
RUN dotnet restore "src/Swipepick.Angular.Web/Swipepick.Angular.Web.csproj"
COPY . .
WORKDIR "/src/src/Swipepick.Angular.Web"
RUN dotnet build "Swipepick.Angular.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swipepick.Angular.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swipepick.Angular.Web.dll"]
