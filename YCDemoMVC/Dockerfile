FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YCDemoMVC/YCDemoMVC.csproj", "YCDemoMVC/"]
RUN dotnet restore "YCDemoMVC/YCDemoMVC.csproj"
COPY . .
WORKDIR "/src/YCDemoMVC"
RUN dotnet build "YCDemoMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YCDemoMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YCDemoMVC.dll"]
