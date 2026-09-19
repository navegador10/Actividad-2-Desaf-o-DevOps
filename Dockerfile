# ---------- Etapa 1: build y publicacion ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos primero solo el csproj para aprovechar la cache de capas de Docker:
# si solo cambia el codigo (no las dependencias), este paso no se repite.
COPY ["ProgramacionV.Api.csproj", "./"]
RUN dotnet restore "ProgramacionV.Api.csproj"

# Copiamos el resto del codigo fuente
COPY . .
RUN dotnet publish "ProgramacionV.Api.csproj" -c Release -o /app/publish --no-restore

# ---------- Etapa 2: imagen final de ejecucion ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ProgramacionV.Api.dll"]
