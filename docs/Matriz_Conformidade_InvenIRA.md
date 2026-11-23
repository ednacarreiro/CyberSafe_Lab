# Matriz de conformidade documental — CyberSafe Lab

**Referências:** Morgado & Cassola (2022), *Activity Providers na Inven!RA*; Morgado et al. (2023), *Inven!RA Architecture...*, Figuras 1, 3, 5, 7 e 9; enunciado da Semana 1, tópico 4 (16–22/11/2026).

| Requisito | Evidência no código | Situação | Ação |
|---|---|---|---|
| Registo dos cinco URLs de serviço e nome | `Features/Registration/GetRegistration.cs` | Implementado | Configurar PUBLIC_BASE_URL no Render (HTTPS) |
| Configuração HTML embutível e nomes coerentes | `Api/Features/ConfigurationEndpoints.cs` | Implementado | Testar em integração com a plataforma |
| Catálogo de parâmetros `name/type` | `Application/Features/Configuration/GetParameters.cs` | Implementado | Verificar nomes da página |
| Catálogo de indicadores qualitativos e quantitativos | `Infrastructure/Repositories/DemoActivityRepository.cs` | Implementado | Validar JSON em ambiente real |
| Deploy `POST` com `activityID` e resposta URL | `Api/Features/DeployEndpoints.cs` | Resposta de exemplo | Ainda não instancia atividade nem persiste o estado |
| Analytics `POST` com `activityID` | `Api/Features/AnalyticsEndpoints.cs` | Dados fictícios | Atualmente ignora `activityID` na seleção de dados; implementar filtro real posteriormente |
| LMS → Inven!RA → AP com substituição de identidade | `docs/Sequencia_Acesso_Aluno_InvenIRA.md` | Documentado | Não confundir representação com implementação; substituição pertence à Inven!RA |
| Provide activity (`POST` à URL devolvida pelo deploy) | Ainda não existe | Por implementar | Excluído expressamente da Semana 1; implementar antes da integração completa |
| Redirecionamento individual e analytics por atividade/aluno | Ainda não existe | Por implementar | Exigível no fluxo integral da Figura 7, não na Semana 1 |
| Proteção dos identificadores originais LMS | Limite de confiança documentado | Não testado em integração | O AP não pode pedir nem armazenar o LMS UserID original |
| Persistência e isolamento por instância/aluno | Repositório de demonstração (sem persistência) | Por implementar | Adicionar persistência para uso real; adequar à infraestrutura Render |
| Diagrama do padrão de criação e implementação | Ainda não existe | Semanas 2–3 | Selecionar padrão e apresentar diagramas pedidos no enunciado |

**Conclusão:** a Semana 1 dispõe de implementação demonstrativa dos cinco serviços pedidos, mas não deve ser apresentada como integração completa e validada com LMS/Inven!RA. Os passos de identidade e acesso do aluno são parte do fluxo arquitetural a preservar na evolução do sistema.
