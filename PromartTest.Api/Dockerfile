#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PromartTest.Api/PromartTest.Api.csproj", "PromartTest.Api/"]
RUN dotnet restore "PromartTest.Api/PromartTest.Api.csproj"
COPY . .
WORKDIR "/src/PromartTest.Api"
RUN dotnet build "PromartTest.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "PromartTest.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PromartTest.Api.dll"]