namespace Incremental.Common.Metrics.Events;

public interface IMetricEventFactoryConfigurationHandler<TMetricEvent> where TMetricEvent : MetricEvent
{
    Task<TMetricEvent> ConfigureAsync(TMetricEvent @event, CancellationToken cancellationToken = default);
}