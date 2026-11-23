using CyberSafeLab.Application.Features.Configuration;
namespace CyberSafeLab.Api.Features;
public static class ConfigurationEndpoints
{
 public static void Map(WebApplication app)
 {
  app.MapGet("/configuracao-atividade.html", () => Results.Content(Page, "text/html; charset=utf-8"));
  app.MapGet("/json-params-atividade", (GetParameters handler) => Results.Json(handler.Execute()));
 }
 private const string Page = """
<!DOCTYPE html><html lang="pt-PT"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>CyberSafe Lab — Configuração</title>
<style>body{background:#f0f6f4;font:16px system-ui,Arial;max-width:720px;margin:30px auto;padding:15px;color:#173f35}main{padding:28px;background:#fff;border-radius:14px;border:1px solid #bed6cc}h1{color:#08745c}label{display:block;font-weight:650;margin-top:18px}input,textarea,select{display:block;box-sizing:border-box;width:100%;padding:10px;margin-top:6px;border:1px solid #8da9a0;border-radius:7px;font:inherit}p{line-height:1.5}</style></head>
<body><main><h1>CyberSafe Lab</h1><p>Configuração de cenários educativos simulados de cibersegurança.</p>
<label for="resumo">Resumo</label><input id="resumo" name="resumo" value="Identificação de riscos em incidentes simulados de cibersegurança">
<label for="instrucoes">Instruções</label><textarea id="instrucoes" name="instrucoes" rows="3">Analisar o incidente, identificar o risco e propor uma medida corretiva.</textarea>
<label for="cenario">Cenário</label><select id="cenario" name="cenario"><option value="phishing">Phishing</option><option value="acesso_nao_autorizado">Acesso não autorizado</option><option value="configuracao_insegura">Configuração insegura</option></select>
<label for="dificuldade">Dificuldade</label><select id="dificuldade" name="dificuldade"><option value="inicial">Inicial</option><option value="intermedia">Intermédia</option></select>
<p><small>Versão académica de demonstração — Semana 1.</small></p></main></body></html>
""";
}
