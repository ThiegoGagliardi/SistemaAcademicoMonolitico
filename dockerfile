# 1. Estágio de Debug (Usado pelo VS Code para attach)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS debug
WORKDIR /src

# Configuração para Debug: Instalação do vsdbg (necessário para o VS Code)
RUN apt-get update \
    && apt-get install -y unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

# Define as variáveis de ambiente necessárias para o Debug
ENV PATH $PATH:/vsdbg
ENV ASPNETCORE_ENVIRONMENT=Development

# Copia e Restaura as dependências
COPY ["SistemaAcademicoMonolitico.csproj", "./"]
RUN dotnet restore

# Copia o restante do código-fonte
COPY . .

# *** NOVO PASSO CRUCIAL: FORÇAR A COMPILAÇÃO ***
# Compila o projeto no modo Debug para garantir que o binário exista.
RUN dotnet build "SistemaAcademicoMonolitico.csproj" -c Debug -o /app/build

# Comando de entrada: Executa a DLL, que é o formato de saída garantido.
# O caminho correto para a DLL (Debug/net8.0/SistemaAcademicoMonolitico.dll) é determinado pelo dotnet build.
# Aqui usamos o /app/build, que é o destino que definimos acima.
ENTRYPOINT [ "dotnet", "/app/build/SistemaAcademicoMonolitico.dll" ]

# ====================================================================

# 2. Estágio de Publish (Para Geração de Binários de Produção) - INALTERADO/RECOMENDADO
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src
COPY ["SistemaAcademicoMonolitico.csproj", "./"]
RUN dotnet restore
COPY . .
RUN dotnet publish "SistemaAcademicoMonolitico.csproj" -c Release -o /app/publish

# ====================================================================

# 3. Estágio de Release (Final) - INALTERADO/RECOMENDADO
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "SistemaAcademicoMonolitico.dll"]