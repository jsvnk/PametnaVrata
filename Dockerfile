# Step 1: Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Step 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PametnaVrata.csproj", "./"]
RUN dotnet restore "./PametnaVrata.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PametnaVrata.csproj" -c Release -o /app/build

# Step 3: Publish
FROM build AS publish
RUN dotnet publish "PametnaVrata.csproj" -c Release -o /app/publish

# Step 4: Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PametnaVrata.dll", "--enviroment=Development"]
