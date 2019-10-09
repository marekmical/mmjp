FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["Jeppesen/Jeppesen.csproj", "Jeppesen/"] 
RUN dotnet restore "Jeppesen/Jeppesen.csproj"
COPY . .
WORKDIR "/src/Jeppesen"
RUN dotnet build "Jeppesen.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Jeppesen.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Jeppesen.dll"]

RUN apt-get update && apt-get install -y \
	nmap \
	iputils-ping
