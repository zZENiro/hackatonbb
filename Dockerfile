FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["hackatonbb.csproj","./"]
RUN dotnet restore "./hackatonbb.csproj"
COPY . ./															
RUN dotnet build "hackatonbb.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "hackatonbb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet","hackatonbb.dll"]