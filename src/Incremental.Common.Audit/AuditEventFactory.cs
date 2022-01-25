namespace Incremental.Common.Audit;

public class AuditEventFactory : IAuditEventFactory
{
    public async Task<AuditEvent> CreateAuditEventAsync(CancellationToken cancellationToken)
    {
        return new AuditEvent();
    }
}