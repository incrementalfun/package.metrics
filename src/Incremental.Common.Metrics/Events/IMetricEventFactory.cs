namespace Incremental.Common.Metrics.Events;

public interface IMetricEventFactory
{
    Task<TMetricEvent> CreateMetricEventAsync<TMetricEvent>(string name, Action<TMetricEvent>?  configure = default, CancellationToken cancellationToken = default) where TMetricEvent : MetricEvent, new();
}