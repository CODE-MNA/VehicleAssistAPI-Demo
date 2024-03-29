FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5264
ENV ASPNETCORE_URLS=http://+:5264

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# copy all the layers' csproj files into respective folders
COPY ["./src/VehicleAssist.APIContracts/VehicleAssist.APIContracts.csproj", "src/VehicleAssist.APIContracts/"]
COPY ["./src/VehicleAssist.Application/VehicleAssist.Application.csproj", "src/VehicleAssist.Application/"]
COPY ["./src/VehicleAssist.Infrastructure/VehicleAssist.Infrastructure.csproj", "src/VehicleAssist.Infrastructure/"]
COPY ["./src/VehicleAssist.Domain/VehicleAssist.Domain.csproj", "src/VehicleAssist.Domain/"]
COPY ["./src/VehicleAssist.API/VehicleAssist.API.csproj", "src/VehicleAssist.API/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/VehicleAssist.API/VehicleAssist.API.csproj"

COPY . .

# run build over the API project
WORKDIR "/src"
RUN dotnet build -c Debug -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Debug -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .


ENTRYPOINT [ "dotnet", "VehicleAssist.API.dll" ]
