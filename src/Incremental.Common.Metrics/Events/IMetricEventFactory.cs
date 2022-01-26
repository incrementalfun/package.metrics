namespace Incremental.Common.Metrics.Events;

public interface IMetricEventFactory
{
    Task<TMetricEvent> CreateMetricEventAsync<TMetricEvent>(string name, CancellationToken cancellationToken = default) where TMetricEvent : MetricEvent, new();
}