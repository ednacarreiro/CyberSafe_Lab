using CyberSafeLab.Application.Abstractions;
using CyberSafeLab.Domain;
namespace CyberSafeLab.Infrastructure.Repositories;
public sealed class DemoActivityRepository : IActivityRepository
{
 public ActivityDefinition GetDefinition() => new("CyberSafe Lab — Simulador de Incidentes de Cibersegurança", "Cenários educativos e simulados de segurança informática");
 public AnalyticsCatalog GetCatalog() => new(
  [new("cenario_analisado", "text/plain"), new("medida_corretiva", "text/plain")],
  [new("atividade_concluida", "boolean"), new("pontuacao", "integer")]);
 public IReadOnlyList<StudentAnalytics> GetExampleAnalytics(string activityId) =>
 [new("demo-aluno-1001", [new("atividade_concluida","boolean", true), new("pontuacao","integer",85)],
   [new("cenario_analisado","text/plain","phishing"),new("medida_corretiva","text/plain","Verificar o remetente e reportar a mensagem suspeita")]),
  new("demo-aluno-1002",[new("atividade_concluida","boolean",false),new("pontuacao","integer",40)],
   [new("cenario_analisado","text/plain","acesso_nao_autorizado"),new("medida_corretiva","text/plain","Ativar autenticação multifator")])];
}
