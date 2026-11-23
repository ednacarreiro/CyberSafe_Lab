using CyberSafeLab.Application.Abstractions;
using CyberSafeLab.Domain;
namespace CyberSafeLab.Application.Features.Analytics;
public sealed record AnalyticsRequest(string? ActivityID);
public sealed class GetActivityAnalytics(IActivityRepository repo) { public IReadOnlyList<StudentAnalytics> Execute(string activityId) => repo.GetExampleAnalytics(activityId); }
