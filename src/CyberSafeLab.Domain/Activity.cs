using System.Text.Json.Serialization;
namespace CyberSafeLab.Domain;
public sealed record ActivityDefinition(string Name, string Summary);
public sealed record ActivityParameter(string Name, string Type);
public sealed record AnalyticDefinition(string Name, string Type);
public sealed record AnalyticsCatalog(IReadOnlyList<AnalyticDefinition> QualAnalytics, IReadOnlyList<AnalyticDefinition> QuantAnalytics);
public sealed record AnalyticValue(string Name, string Type, object Value);
public sealed record StudentAnalytics([property: JsonPropertyName("inveniraStdID")] string InveniraStdID,
 [property: JsonPropertyName("quantAnalytics")] IReadOnlyList<AnalyticValue> QuantAnalytics,
 [property: JsonPropertyName("qualAnalytics")] IReadOnlyList<AnalyticValue> QualAnalytics);
