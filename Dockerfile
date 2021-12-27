FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AssessoriaCartoesApi/AssessoriaCartoesApi.csproj", "AssessoriaCartoesApi/"]
RUN dotnet restore "AssessoriaCartoesApi/AssessoriaCartoesApi.csproj"
COPY . .
WORKDIR "/src/AssessoriaCartoesApi"
RUN dotnet build "AssessoriaCartoesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AssessoriaCartoesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssessoriaCartoesApi.dll"]