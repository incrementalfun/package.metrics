namespace Incremental.Common.Audit.Events;

public interface IAuditEventFactory
{
    Task<AuditEvent> CreateAuditEventAsync(CancellationToken cancellationToken);
}