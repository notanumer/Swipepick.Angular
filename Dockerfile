#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Swipepick.Angular.Web/Swipepick.Angular.Web.csproj", "Swipepick.Angular.Web/"]
COPY ["Swipepick.Angular.DataAccess/Swipepick.Angular.DataAccess.csproj", "Swipepick.Angular.DataAccess/"]
COPY ["Swipepick.Angular.Domain/Swipepick.Angular.Domain.csproj", "Swipepick.Angular.Domain/"]
COPY ["Swipepick.Angular.Infrastructure.Abstractions/Swipepick.Angular.Infrastructure.Abstractions.csproj", "Swipepick.Angular.Infrastructure.Abstractions/"]
COPY ["Swipepick.Angular.Infrastructure.Common/Swipepick.Angular.Infrastructure.Common.csproj", "Swipepick.Angular.Infrastructure.Common/"]
COPY ["Swipepick.Angular.UseCases/Swipepick.Angular.UseCases.csproj", "Swipepick.Angular.UseCases/"]
COPY ["Swipepick.Angular.DomainServices/Swipepick.Angular.DomainServices.csproj", "Swipepick.Angular.DomainServices/"]
RUN dotnet restore "Swipepick.Angular.Web/Swipepick.Angular.Web.csproj"
COPY . .
WORKDIR "/src/Swipepick.Angular.Web"
RUN dotnet build "Swipepick.Angular.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swipepick.Angular.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swipepick.Angular.Web.dll"]