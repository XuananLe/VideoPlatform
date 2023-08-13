FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VideoPlatform.API/VideoPlatform.API.csproj", "VideoPlatform.API/"]
RUN dotnet restore "VideoPlatform.API/VideoPlatform.API.csproj"
COPY . .
WORKDIR "/src/VideoPlatform.API"
RUN dotnet build "VideoPlatform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoPlatform.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoPlatform.API.dll"]
