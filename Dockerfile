FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /app

EXPOSE 80

COPY . .

RUN dotnet restore "./src/IAGRO.Challenge.sln" --disable-parallel
RUN dotnet publish "./src/IAGRO.Challenge.sln" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "IAGRO.Challenge.Api.dll"]