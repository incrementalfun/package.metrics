namespace Incremental.Common.Audit.Store;

public interface IAuditStore
{
    public Task SaveAsync<TAuditEvent>(TAuditEvent auditEvent, CancellationToken cancellationToken = default);
}