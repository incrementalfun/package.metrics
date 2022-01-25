using Incremental.Common.Audit.Store;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Audit;

public class AuditScopeFactory : IAuditScopeFactory
{
    private readonly ILogger<AuditScopeFactory> _logger;
    private readonly IAuditStore _auditStore;

    public AuditScopeFactory(ILogger<AuditScopeFactory> logger, IAuditStore auditStore)
    {
        _logger = logger;
        _auditStore = auditStore;
    }

    public async Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default)
    {
        return await new AuditScope(_auditStore).StartAsync(cancellationToken);
    }
}