using Incremental.Common.Metrics.Events.WellKnown;
using Incremental.Common.Metrics.Scope;

namespace Incremental.Common.Metrics.Extensions;

public static class MetricScopeFactoryExtensions
{
    public static async Task<IMetricScope> CreateScopeAsync(this IMetricScopeFactory metricScopeFactory, string eventName,
        CancellationToken cancellationToken = default)
    {
        return await metricScopeFactory.CreateScopeAsync<BasicMetricEvent>(eventName, cancellationToken);

    }
}