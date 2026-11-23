using CyberSafeLab.Application.Abstractions;
namespace CyberSafeLab.Application.Features.Deploy;
public sealed record DeployRequest(string? ActivityID);
public sealed class DeployActivity(IUrlBuilder urls)
{
 public string Execute(string activityId) => urls.Absolute("/atividade/" + Uri.EscapeDataString(activityId));
 public static bool IsValid(string? id) => !string.IsNullOrWhiteSpace(id) && id.Length <= 160 && !id.Any(char.IsControl);
}
