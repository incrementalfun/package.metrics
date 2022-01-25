namespace Incremental.Common.Audit.Events;

public interface IAuditEventConfigurationHandler<TAuditEvent> where TAuditEvent : AuditEvent
{
    Task<TAuditEvent> ConfigureAsync(TAuditEvent @event, CancellationToken cancellationToken = default);
}