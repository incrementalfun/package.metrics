namespace Incremental.Common.Audit.Store;

public interface IAuditStore
{
    public Task SaveAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);
}