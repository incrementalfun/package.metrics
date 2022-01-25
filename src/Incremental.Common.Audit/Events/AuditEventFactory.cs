namespace Incremental.Common.Audit.Events;

public class AuditEventFactory : IAuditEventFactory
{
    public async Task<TAuditEvent> CreateAuditEventAsync<TAuditEvent>(CancellationToken cancellationToken) 
        where TAuditEvent : AuditEvent, new()
    {
        return new TAuditEvent();
    }
}