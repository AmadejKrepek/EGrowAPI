# INSTRUCTIONS on creating a Docker image (Developer PowerShell):
#	1. We create a repo using this command (don't forget the dot at the end): docker build -t {repositoryName} .
#	2. We save the image file using this command: docker image save -o {imageName}.tar {repositoryName}
# Image gets saved in project folder.
# Variables marked in {} can be assigned freely.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EGrowAPI.csproj", "."]
RUN dotnet restore "./EGrowAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "EGrowAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EGrowAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EGrowAPI.dll"]