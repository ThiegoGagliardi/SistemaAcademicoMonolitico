# Dockerfile (Corrigido)

# 1. Estágio de Debug (Alvo: debug)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS debug
WORKDIR /src
# ... Instalação do vsdbg ...
# ... Variáveis de ambiente ...

COPY ["SistemaAcademicoMonolitico.csproj", "./"]
RUN dotnet restore

# O código-fonte será injetado via Volume (docker-compose.yml)
COPY . .

# ENTRYPOINT de DEBUG: Usa 'dotnet watch run' para Hot Reload
ENTRYPOINT [ "dotnet", "watch", "--project", "SistemaAcademicoMonolitico.csproj", "run", "--urls", "http://+:8080" ]

# ====================================================================

# 2. Estágio de Publish (Alvo: publish)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
# ... (Inalterado)

# ====================================================================

# 3. Estágio de Release (Final) - Alvo: final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# ENTRYPOINT de RELEASE: Execução rápida da DLL
ENTRYPOINT ["dotnet", "SistemaAcademicoMonolitico.dll"]