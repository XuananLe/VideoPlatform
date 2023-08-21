FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VideoPlatform.Models/VideoPlatform.Models.csproj", "VideoPlatform.Models/"]
RUN dotnet restore "VideoPlatform.Models/VideoPlatform.Models.csproj"
COPY . .
WORKDIR "/src/VideoPlatform.Models"
RUN dotnet build "VideoPlatform.Models.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VideoPlatform.Models.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoPlatform.Models.dll"]
