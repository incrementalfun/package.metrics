namespace Incremental.Common.Audit;

public interface IAuditEventFactory
{
    Task<AuditEvent> CreateAuditEventAsync(CancellationToken cancellationToken);
}