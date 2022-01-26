using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Metrics.Events;

public class MetricEventFactory : IMetricEventFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MetricEventFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<TMetricEvent> CreateMetricEventAsync<TMetricEvent>(string name, Action<TMetricEvent>? configure = default,
        CancellationToken cancellationToken = default) 
        where TMetricEvent : MetricEvent, new()
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        var handler = scope.ServiceProvider.GetService<IMetricEventFactoryConfigurationHandler<TMetricEvent>>();
        
        var @event = new TMetricEvent
        {
            Name = name
        };

        if (handler is not null)
        {
            await handler.ConfigureAsync(@event, cancellationToken);
        }

        configure?.Invoke(@event);

        return @event;
    }
}