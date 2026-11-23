# CyberSafe Lab — Acesso do aluno (Figura 7 da Inven!RA)

**Estado:** diagrama arquitetural de referência, **não** demonstra que o serviço `Provide activity` esteja implementado na Semana 1.

## Diagrama de sequência

```mermaid
sequenceDiagram
    autonumber
    actor Aluno as Active Agent (aluno)
    participant LMS as LMS (Moodle)
    participant IR as Inven!RA (broker)
    participant AP as CyberSafe Lab (Activity Provider)
    Aluno->>LMS: Abre disciplina e seleciona URL da atividade
    LMS->>IR: Solicita atividade (URL Inven!RA + LMS UserID)
    Note over IR: Associa utilizador e substitui LMS UserID por Inven!RA UserID
    IR->>AP: Obtém URL da instância do AP
    Note over IR,AP: Instância obtida anteriormente no deploy; URL do AP não é publicado diretamente no LMS
    IR->>AP: POST URL da instância (activityID, Inven!RAstdID, json_params)
    Note over AP: Nunca recebe LMS UserID original
    AP-->>IR: URL individual para o aluno
    IR-->>Aluno: Redireciona para URL individual
    Aluno->>AP: Interage com a atividade simulada
    Note over AP: Regista analytics por activityID + Inven!RAstdID
```

> O procedimento de mapeamento de identidades, a emissão dos URLs Inven!RA e a ligação ao LMS são responsabilidades da plataforma Inven!RA; **não** são funcionalidades a programar no CyberSafe Lab. O AP apenas deve aceitar a identificação intermediada, mantendo a associação à instância.

## Contratos de interoperabilidade (relatório Morgado e Cassola, 2022)

**Registo JSON:** `name`, `config_url`, `json_params_url`, `user_url`, `analytics_url`, `analytics_list_url`.

**Configuração:** `GET config_url` devolve HTML embutível; `GET json_params_url` devolve lista `{ "name", "type" }` com nomes correspondentes aos controlos da página.

**Catálogo:** `GET analytics_list_url` devolve `qualAnalytics` e `quantAnalytics`, com `{ "name", "type" }`.

**Deploy:** `POST user_url` com `{"activityID":"instancia-1"}` devolve o URL do AP para a instância. O AP tem de conseguir instanciá-la numa fase funcional futura.

**Acesso do aluno (fase futura):** `POST` ao URL devolvido pelo deploy, com:

```json
{
  "activityID": "instancia-1",
  "Inven!RAstdID": "aluno-anonimizado-1",
  "json_params": {
    "resumo": "Resumo do exercício",
    "instrucoes": "Instruções",
    "cenario": "phishing",
    "dificuldade": "inicial"
  }
}
```

**Resposta:** URL para redirecionamento do aluno. O AP preserva os parâmetros `activityID` e `Inven!RAstdID` na sua associação interna, não enviando o identificador LMS original.

**Analytics:** `POST analytics_url` com `{"activityID":"instancia-1"}` devolve lista de alunos com `inveniraStdID`, `qualAnalytics` e `quantAnalytics`, cada indicador com `name`, `type` e `value`.

## Referência

Morgado et al. (2023), *Inven!RA Architecture for Sustainable Deployment of Immersive Learning Environments*, Figura 7, p. 8; Morgado & Cassola (2022), *Activity Providers na Inven!RA*, pp. 1–4.
