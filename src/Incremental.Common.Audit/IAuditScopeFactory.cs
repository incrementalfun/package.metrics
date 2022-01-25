using Incremental.Common.Audit.Events;

namespace Incremental.Common.Audit;

public interface IAuditScopeFactory
{
    Task<IAuditScope> CreateScopeAsync<TAuditEvent>(CancellationToken cancellationToken = default) where TAuditEvent : AuditEvent, new();
    Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default);
}