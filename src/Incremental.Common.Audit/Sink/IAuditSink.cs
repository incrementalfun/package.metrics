namespace Incremental.Common.Audit.Sink;

public interface IAuditSink
{
    public Task SaveAsync<TAuditEvent>(TAuditEvent auditEvent, CancellationToken cancellationToken = default);
}