using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Sink;
using Incremental.Common.Metrics.Sinks.EntityFramework.Context;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Metrics.Sinks.EntityFramework;

public class EntityFrameworkMetricSink<TContext> : IMetricSink where TContext : IncrementalMetricsDbContext
{
    private readonly ILogger<EntityFrameworkMetricSink<TContext>> _logger;
    private readonly TContext _incrementalMetricsDbContext;

    public EntityFrameworkMetricSink(ILogger<EntityFrameworkMetricSink<TContext>> logger, TContext incrementalMetricsDbContext)
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