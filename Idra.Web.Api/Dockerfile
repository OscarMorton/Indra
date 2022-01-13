#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Idra.Web.Api/Idra.Web.Api.csproj", "Idra.Web.Api/"]
RUN dotnet restore "Idra.Web.Api/Idra.Web.Api.csproj"
COPY . .
WORKDIR "/src/Idra.Web.Api"
RUN dotnet build "Idra.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Idra.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Idra.Web.Api.dll"]