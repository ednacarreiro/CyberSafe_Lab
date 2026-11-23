using CyberSafeLab.Application.Features.Deploy;
namespace CyberSafeLab.Api.Features;
public static class DeployEndpoints
{
 public static void Map(WebApplication app) => app.MapPost("/deploy-atividade", (DeployRequest request, DeployActivity handler) =>
  !DeployActivity.IsValid(request.ActivityID) ? (IResult)Results.BadRequest(new { erro = "activityID obrigatório (máximo 160 caracteres)." }) :
  Results.Text(handler.Execute(request.ActivityID!), "text/plain; charset=utf-8"));
}
