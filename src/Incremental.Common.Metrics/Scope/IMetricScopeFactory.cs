using Incremental.Common.Metrics.Events;

namespace Incremental.Common.Metrics.Scope;

public interface IMetricScopeFactory
{
    Task<IMetricScope> CreateScopeAsync<TMetricEvent>(string eventName, Action<TMetricEvent>? configure = default, CancellationToken cancellationToken = default) where TMetricEvent : MetricEvent, new();
}