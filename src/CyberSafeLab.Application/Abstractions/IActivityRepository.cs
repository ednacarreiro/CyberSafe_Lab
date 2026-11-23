using CyberSafeLab.Domain;
namespace CyberSafeLab.Application.Abstractions;
// Nesta fase o repositório disponibiliza apenas dados académicos fictícios.
public interface IActivityRepository
{
  ActivityDefinition GetDefinition();
  AnalyticsCatalog GetCatalog();
  IReadOnlyList<StudentAnalytics> GetExampleAnalytics(string activityId);
}
