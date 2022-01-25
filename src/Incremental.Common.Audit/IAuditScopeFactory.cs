using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Scope;

namespace Incremental.Common.Audit;

public interface IAuditScopeFactory
{
    Task<IAuditScope> CreateScopeAsync<TAuditEvent>(string eventName, CancellationToken cancellationToken = default) where TAuditEvent : AuditEvent, new();
}