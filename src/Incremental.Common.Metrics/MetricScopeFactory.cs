using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Scope;
using Incremental.Common.Metrics.Sink;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Metrics;

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

    public async Task<IMetricScope> CreateScopeAsync<TAuditEvent>(string eventName, CancellationToken cancellationToken = default) 
        where TAuditEvent : MetricEvent, new()
    {
        return await new MetricScope<TAuditEvent>(
                sink: _metricSink, 
                @event: await _metricEventFactory.CreateMetricEventAsync<TAuditEvent>(eventName,cancellationToken))
            .StartAsync(cancellationToken);
    }
}