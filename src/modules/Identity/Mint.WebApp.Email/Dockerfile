#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/modules/Identity/Mint.WebApp.Email/Mint.WebApp.Email.csproj", "src/modules/Identity/Mint.WebApp.Email/"]
RUN dotnet restore "src/modules/Identity/Mint.WebApp.Email/Mint.WebApp.Email.csproj"
COPY . .
WORKDIR "/src/src/modules/Identity/Mint.WebApp.Email"
RUN dotnet build "Mint.WebApp.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mint.WebApp.Email.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mint.WebApp.Email.dll"]