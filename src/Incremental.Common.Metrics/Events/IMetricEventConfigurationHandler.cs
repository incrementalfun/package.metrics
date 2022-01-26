namespace Incremental.Common.Metrics.Events;

public interface IMetricEventConfigurationHandler<TMetricEvent> where TMetricEvent : MetricEvent
{
    Task<TMetricEvent> ConfigureAsync(TMetricEvent @event, CancellationToken cancellationToken = default);
}