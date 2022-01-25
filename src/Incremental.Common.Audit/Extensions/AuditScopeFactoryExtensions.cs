using Incremental.Common.Audit.Events.WellKnown;

namespace Incremental.Common.Audit.Extensions;

public static class AuditScopeFactoryExtensions
{
    public static async Task<IAuditScope> CreateScopeAsync(this IAuditScopeFactory auditScopeFactory, string eventName,
        CancellationToken cancellationToken = default)
    {
        return await auditScopeFactory.CreateScopeAsync<BasicAuditEvent>(eventName, cancellationToken);

    }
}