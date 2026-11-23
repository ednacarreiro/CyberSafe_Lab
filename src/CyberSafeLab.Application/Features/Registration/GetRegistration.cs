using CyberSafeLab.Application.Abstractions;
namespace CyberSafeLab.Application.Features.Registration;
public sealed record ActivityRegistration(string name, string config_url, string json_params_url, string user_url, string analytics_url, string analytics_list_url);
public sealed class GetRegistration(IActivityRepository repo, IUrlBuilder urls)
{
 public ActivityRegistration Execute() => new(repo.GetDefinition().Name,
  urls.Absolute("/configuracao-atividade.html"), urls.Absolute("/json-params-atividade"),
  urls.Absolute("/deploy-atividade"), urls.Absolute("/analytics-atividade"), urls.Absolute("/lista-analytics-atividade"));
}
