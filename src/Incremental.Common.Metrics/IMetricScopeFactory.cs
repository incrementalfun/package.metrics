using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Scope;

namespace Incremental.Common.Metrics;

public interface IMetricScopeFactory
{
    Task<IMetricScope> CreateScopeAsync<TMetricEvent>(string eventName, CancellationToken cancellationToken = default) where TMetricEvent : MetricEvent, new();
}