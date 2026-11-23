# Decisões de arquitetura — Semana 1

## Separação de responsabilidades

API (HTTP) → Application (casos de uso agrupados por funcionalidade) → Domain (contratos de dados). A Infrastructure implementa interfaces da Application e é registada pela API; Domain não conhece Infrastructure ou API.

```text
src/
  CyberSafeLab.Domain/
    Activity.cs
  CyberSafeLab.Application/
    Abstractions/IActivityRepository.cs
    Abstractions/IUrlBuilder.cs
    Features/Registration/GetRegistration.cs
    Features/Configuration/GetParameters.cs
    Features/Deploy/DeployActivity.cs
    Features/Analytics/GetAvailableAnalytics.cs
    Features/Analytics/GetActivityAnalytics.cs
  CyberSafeLab.Infrastructure/
    Repositories/DemoActivityRepository.cs
    Hosting/PublicUrlBuilder.cs
  CyberSafeLab.Api/
    Features/ConfigurationEndpoints.cs
    Features/DeployEndpoints.cs
    Features/AnalyticsEndpoints.cs
    Program.cs
```

Os cinco caminhos são mantidos iguais aos indicados na especificação Inven!RA. A arquitetura é deliberadamente leve: um projeto por camada e vertical slices na Application/Api. Não foi adicionado MediatR nem base de dados por serem desnecessários para esta fase.

## Limites

- A página HTML não executa um simulador; configura uma atividade.
- O deploy devolve o URL do serviço futuro; não cria sessão persistente.
- A resposta de analytics é fictícia e não varia por `activityID`.
- O serviço Provide activity não está implementado.

## Padrões da fase seguinte

Quando a implementação tiver mais do que uma forma real de construir cenários, pode ser analisado Factory Method, Abstract Factory ou Builder, justificando vantagens e custos. Não declarar aplicado um padrão apenas porque existe injeção de dependências.
