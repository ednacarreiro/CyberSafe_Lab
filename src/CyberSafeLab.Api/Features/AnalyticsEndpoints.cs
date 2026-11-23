using CyberSafeLab.Application.Features.Analytics;
using CyberSafeLab.Application.Features.Deploy;
namespace CyberSafeLab.Api.Features;
public static class AnalyticsEndpoints
{
 public static void Map(WebApplication app)
 {
  app.MapGet("/lista-analytics-atividade", (GetAvailableAnalytics handler) => Results.Json(handler.Execute()));
  app.MapPost("/analytics-atividade", (AnalyticsRequest request, GetActivityAnalytics handler) =>
   !DeployActivity.IsValid(request.ActivityID) ? (IResult)Results.BadRequest(new { erro = "activityID obrigatório (máximo 160 caracteres)." }) :
   Results.Json(handler.Execute(request.ActivityID!)));
 }
}
