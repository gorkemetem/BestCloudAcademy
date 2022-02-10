FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BestCloudAcademyAPI/BestCloudAcademyAPI.csproj", "BestCloudAcademyAPI/"]
RUN dotnet restore "BestCloudAcademyAPI/BestCloudAcademyAPI.csproj"
COPY . .
WORKDIR "/src/BestCloudAcademyAPI"
RUN dotnet build "BestCloudAcademyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BestCloudAcademyAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BestCloudAcademyAPI.dll"]