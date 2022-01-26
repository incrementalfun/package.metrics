using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Metrics.Events;

public class MetricEventFactory : IMetricEventFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MetricEventFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<TMetricEvent> CreateMetricEventAsync<TMetricEvent>(string name, CancellationToken cancellationToken = default) 
        where TMetricEvent : MetricEvent, new()
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        var handler = scope.ServiceProvider.GetService<IMetricEventConfigurationHandler<TMetricEvent>>();
        
        var @event = new TMetricEvent
        {
            Name = name
        };

        if (handler is not null)
        {
            await handler.ConfigureAsync(@event, cancellationToken);
        }

        return @event;
    }
}