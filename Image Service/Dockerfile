#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Image Service/Image Service.csproj", "Image Service/"]
COPY ["Logic/Logic.csproj", "Logic/"]
COPY ["Factory/Factory.csproj", "Factory/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "Image Service/Image Service.csproj"
COPY . .
WORKDIR "/src/Image Service"
RUN dotnet build "Image Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Image Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Image Service.dll"]