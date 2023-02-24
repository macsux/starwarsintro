FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR src
# copy nuget.config files at solution and project levels
# copy any local nuget sources that are subfolders of the solution
COPY ["StarWars/StarWars.csproj", "StarWars/StarWars.csproj"]
RUN dotnet restore "StarWars\StarWars.csproj"
COPY . .
RUN dotnet msbuild /p:RestorePackages=false /t:PublishLayer /p:PublishDir=/layer/ /p:DockerLayer=All "StarWars/StarWars.csproj"
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run
WORKDIR /app
COPY --from=build /layer/package ./
COPY --from=build /layer/earlypackage ./
COPY --from=build /layer/project ./
COPY --from=build /layer/app ./
ENTRYPOINT ["dotnet", "StarWars.dll"]
