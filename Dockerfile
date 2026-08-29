# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar el proyecto
COPY ["evaluacion20262.csproj", "./"]

# Restaurar dependencias
RUN dotnet restore "evaluacion20262.csproj"

# Copiar el resto del código
COPY . .

# Compilar y publicar
RUN dotnet publish "evaluacion20262.csproj" -c Release -o /app/publish /p:UseAppHost=false


# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copiar la aplicación publicada
COPY --from=build /app/publish .

# Render proporciona el puerto mediante PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}

ENTRYPOINT ["dotnet", "evaluacion20262.dll"]