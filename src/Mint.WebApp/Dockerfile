FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV NODE_VERSION=16.8.1
SHELL ["pwsh", "-Command", "$ErrorActionPreference = 'Stop';$ProgressPreference='silentlyContinue';"]
RUN Invoke-WebRequest -OutFile nodejs.zip -UseBasicParsing "https://nodejs.org/dist/v$($env:NODE_VERSION)/node-v$($env:NODE_VERSION)-win-x64.zip"; `
    Expand-Archive nodejs.zip -DestinationPath C:\; `
    Rename-Item "C:\node-v$($env:NODE_VERSION)-win-x64" c:\nodejs
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY --from=downloadnodejs C:\\nodejs\\ C:\\Windows\\system32\\
WORKDIR /src
COPY ["src/Mint.WebApp/Mint.WebApp.csproj", "src/Mint.WebApp/"]
COPY ["src/Mint.Domain/Mint.Domain.csproj", "src/Mint.Domain/"]
COPY ["src/Mint.Infrastructure/Mint.Infrastructure.csproj", "src/Mint.Infrastructure/"]
RUN dotnet restore "src/Mint.WebApp/Mint.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Mint.WebApp"
RUN dotnet build "Mint.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mint.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mint.WebApp.dll"]