using CyberSafeLab.Domain;
namespace CyberSafeLab.Application.Features.Configuration;
public sealed class GetParameters
{
 public IReadOnlyList<ActivityParameter> Execute() =>
 [new("resumo", "text/plain"), new("instrucoes", "text/plain"),new("cenario", "text/plain"),new("dificuldade", "text/plain")];
}
