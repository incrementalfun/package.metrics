using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Audit.Events;

public class AuditEventFactory : IAuditEventFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AuditEventFactory(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<TAuditEvent> CreateAuditEventAsync<TAuditEvent>(string eventName, CancellationToken cancellationToken = default) 
        where TAuditEvent : AuditEvent, new()
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        var handler = scope.ServiceProvider.GetService<IAuditEventConfigurationHandler<TAuditEvent>>();
        
        var @event = new TAuditEvent
        {
            Name = eventName
        };

        if (handler is not null)
        {
            await handler.ConfigureAsync(@event, cancellationToken);
        }

        return @event;
    }
}