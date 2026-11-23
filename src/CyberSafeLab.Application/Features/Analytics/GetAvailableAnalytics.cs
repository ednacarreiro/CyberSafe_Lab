using CyberSafeLab.Application.Abstractions;
using CyberSafeLab.Domain;
namespace CyberSafeLab.Application.Features.Analytics;
public sealed class GetAvailableAnalytics(IActivityRepository repo) { public AnalyticsCatalog Execute() => repo.GetCatalog(); }
