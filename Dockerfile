FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["GreatDesafio.csproj", "./"]
RUN dotnet restore "./GreatDesafio.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GreatDesafio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GreatDesafio.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.1

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GreatDesafio.dll"]