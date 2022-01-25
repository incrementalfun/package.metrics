namespace Incremental.Common.Audit.Events;

public class AuditEventFactory : IAuditEventFactory
{
    public async Task<AuditEvent> CreateAuditEventAsync(CancellationToken cancellationToken)
    {
        return new AuditEvent();
    }
}