# Osnovna slika za gradnjo aplikacije z .NET SDK 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiranje datoteke projekta in obnovitev odvisnosti
COPY ["PametnaVrata.csproj", "./"]
RUN dotnet restore "PametnaVrata.csproj"

# Kopiranje vseh datotek in izgradnja projekta
COPY . .
RUN dotnet build "PametnaVrata.csproj" -c Release -o /app/build

# Objava aplikacije
RUN dotnet publish "PametnaVrata.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Osnovna slika za zagon aplikacije z .NET Runtime 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Kopiranje objavljenih datotek iz prejšnje faze
COPY --from=build /app/publish .

# Odpiranje vrat v zabojniku
EXPOSE 80

# Nastavitev vstopne točke za zagon aplikacije
ENTRYPOINT ["dotnet", "PametnaVrata.dll"]
