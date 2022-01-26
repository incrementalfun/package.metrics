using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Sink;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Metrics.Scope;

public class MetricScopeFactory : IMetricScopeFactory
{
    private readonly ILogger<MetricScopeFactory> _logger;
    private readonly IMetricSink _metricSink;
    private readonly IMetricEventFactory _metricEventFactory;

    public MetricScopeFactory(ILogger<MetricScopeFactory> logger, IMetricSink metricSink, IMetricEventFactory metricEventFactory)
    {
        _logger = logger;
        _metricSink = metricSink;
        _metricEventFactory = metricEventFactory;
    }

    public async Task<IMetricScope> CreateScopeAsync<TMetricEvent>(string eventName, Action<TMetricEvent>? configure = default, CancellationToken cancellationToken = default) 
        where TMetricEvent : MetricEvent, new()
    {
        return await new MetricScope<TMetricEvent>(
                sink: _metricSink, 
                @event: await _metricEventFactory.CreateMetricEventAsync<TMetricEvent>(eventName, configure, cancellationToken))
            .StartAsync(cancellationToken);
    }
}