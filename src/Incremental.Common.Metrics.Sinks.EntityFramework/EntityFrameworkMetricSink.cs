using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Sink;
using Incremental.Common.Metrics.Sinks.EntityFramework.Context;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Metrics.Sinks.EntityFramework;

public class EntityFrameworkMetricSink : IMetricSink
{
    private readonly ILogger<EntityFrameworkMetricSink> _logger;
    private readonly IncrementalMetricsDbContext _incrementalMetricsDbContext;

    public EntityFrameworkMetricSink(ILogger<EntityFrameworkMetricSink> logger, IncrementalMetricsDbContext incrementalMetricsDbContext)
    {
        _logger = logger;
        _incrementalMetricsDbContext = incrementalMetricsDbContext;
    }

    public async Task SaveAsync<TMetricEvent>(TMetricEvent @event, CancellationToken cancellationToken = default) 
        where TMetricEvent : MetricEvent
    {
        await _incrementalMetricsDbContext.Set<TMetricEvent>().AddAsync(@event, cancellationToken);

        await _incrementalMetricsDbContext.SaveChangesAsync(cancellationToken);
    }
}