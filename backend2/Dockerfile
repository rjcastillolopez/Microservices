FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY backend2.csproj .
RUN dotnet restore "backend2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "backend2.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "backend2.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "backend2.dll"]