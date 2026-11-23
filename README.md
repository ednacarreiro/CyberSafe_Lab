# CyberSafe Lab — Clean Architecture + Vertical Slices — ASP.NET Core 10

Projeto académico para Arquitetura e Padrões de Software — Semana 1, 16–22 de novembro de 2026.

## Organização

- **Domain:** conceitos ActivityDefinition, ActivityParameter, AnalyticsCatalog, StudentAnalytics; sem dependências de framework.
- **Application:** casos de uso por vertical slice: Registration, Configuration, Deploy, Analytics; contratos IActivityRepository e IUrlBuilder.
- **Infrastructure:** dados de demonstração e construção segura de URLs públicos.
- **Api:** Minimal APIs com endpoints por funcionalidade; composição/injeção de dependências em Program.cs.

A lógica de cada funcionalidade atravessa as camadas sem criar uma pasta genérica Services com responsabilidades misturadas. Para a primeira semana não há EF Core nem PostgreSQL porque o enunciado pede **dados de exemplo**. A persistência pode ser adicionada numa evolução futura.

## Instalação Windows (PowerShell + VS Code)

1. Instalar **.NET SDK 10**, **Git** e **Visual Studio Code** com a extensão C# Dev Kit.
2. Extrair o ZIP e abrir o VS Code na pasta `CyberSafe_Lab_ASPNETCore10`.
3. No terminal PowerShell, executar:

```powershell
dotnet --version
dotnet restore .\src\CyberSafeLab.Api\CyberSafeLab.Api.csproj
dotnet build .\src\CyberSafeLab.Api\CyberSafeLab.Api.csproj
$env:PORT="3000"
dotnet run --project .\src\CyberSafeLab.Api\CyberSafeLab.Api.csproj --no-launch-profile
```

Abrir `http://localhost:3000/health`, `http://localhost:3000/registo-atividade` e `http://localhost:3000/configuracao-atividade.html`.

Num **segundo terminal PowerShell**, executar:

```powershell
.	ests\Testar-Servicos.ps1
```

## Os cinco serviços exigidos

| Campo de registo | Método | Caminho |
|---|---|---|
| config_url | GET | /configuracao-atividade.html |
| json_params_url | GET | /json-params-atividade |
| user_url | POST | /deploy-atividade |
| analytics_list_url | GET | /lista-analytics-atividade |
| analytics_url | POST | /analytics-atividade |

`GET /registo-atividade` devolve o ficheiro JSON de registo da Inven!RA. `GET /health` serve para monitorização no Render.

O POST de deploy recebe `{"activityID":"turma-2026-01"}` e devolve em texto um URL reservado para o futuro serviço da atividade. O POST de analytics recebe o mesmo JSON e devolve dados fictícios, **não armazenados e não provenientes de utilizadores reais**.

**O sexto serviço (*Provide activity*) não é implementado**, de acordo com o enunciado da Semana 1.

## Criar repositório GitHub

Na raiz do projeto (onde está o Dockerfile), executar:

```powershell
git init
git add .
git commit -m "Semana 1: Activity Provider ASP.NET Core 10 com Clean Architecture e Vertical Slices"
git branch -M main
git remote add origin https://github.com/UTILIZADOR/REPOSITORIO.git
git push -u origin main
```

Antes de executar `git remote add`, criar o repositório **vazio** no GitHub e substituir `UTILIZADOR/REPOSITORIO` pelo endereço real. Não incluir segredos no Git.

## Publicar no Render

1. Entrar em https://render.com/ e associar a conta GitHub.
2. **New > Web Service > Build and deploy from a Git repository**; selecionar o repositório.
3. Escolher **Language/Runtime: Docker** e **Dockerfile Path: `./Dockerfile`**; branch `main`.
4. Selecionar o plano compatível com o orçamento (se houver opção gratuita disponível, podes utilizá-la para testes).
5. Definir **Health Check Path: `/health`** e variável **`ASPNETCORE_ENVIRONMENT=Production`**.
6. Criar o serviço e consultar os logs de compilação/publicação. O servidor escuta `0.0.0.0:$PORT` (por omissão `10000`).
7. Copiar o URL HTTPS realmente atribuído pelo Render, por exemplo `https://NOME-REAL.onrender.com`.
8. Em **Environment > Add Environment Variable**, definir `PUBLIC_BASE_URL` com o URL verdadeiro, sem barra final. Guardar e reimplementar se necessário.
9. Abrir `https://NOME-REAL.onrender.com/registo-atividade` e confirmar que os cinco endereços apontam para o teu Render.
10. No PowerShell local executar:

```powershell
.	ests\Testar-Servicos.ps1 -BaseUrl "https://NOME-REAL.onrender.com"
```

11. Entregar no Moodle o **URL HTTPS real**, depois de confirmar a resposta dos cinco serviços.

### Problemas comuns

- **Render sem porta:** verificar a variável `PORT` e os logs. O código já faz bind a `0.0.0.0`.
- **Registo devolve localhost:** falta configurar `PUBLIC_BASE_URL` no Render.
- **Falha ao compilar:** confirmar runtime Docker e raiz do repositório correta.
- **Testes não correm:** executar `Set-ExecutionPolicy -Scope Process Bypass` apenas na sessão PowerShell atual.
- **Serviço adormecido em planos gratuitos:** o primeiro acesso pode ser mais lento; verificar condições atuais do Render.

## Limitações e segurança

Este é um protótipo académico de demonstração. Não há base de dados, autenticação, registos reais de estudantes ou funcionalidade de simulação interativa nesta fase. Não utilizar dados pessoais. Para uso real acrescentar proteção de dados, persistência, autenticação/autorização, auditoria e testes automatizados de integração e carga. A futura atividade deve confirmar o formato exigido pelos serviços de entrada e o contexto exato de instância.

## Bibliografia

- Morgado, L. & Cassola, F. (2022). *Activity Providers na Inven!RA*.
- Universidade Aberta (2026). *Atividade prática — usar padrões de criação no projeto*.
- https://render.com/docs/docker
- https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-10.0
