using Incremental.Common.Metrics.Events;

namespace Incremental.Common.Metrics.Sink;

public interface IMetricSink
{
    public Task SaveAsync<TMetricEvent>(TMetricEvent @event, CancellationToken cancellationToken = default)
        where TMetricEvent : MetricEvent;
}