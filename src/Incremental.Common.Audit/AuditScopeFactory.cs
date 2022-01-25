using Incremental.Common.Audit.Store;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Audit;

public class AuditScopeFactory : IAuditScopeFactory
{
    private readonly ILogger<AuditScopeFactory> _logger;
    private readonly IAuditStore _auditStore;
    private readonly IAuditEventFactory _auditEventFactory;

    public AuditScopeFactory(ILogger<AuditScopeFactory> logger, IAuditStore auditStore, IAuditEventFactory auditEventFactory)
    {
        _logger = logger;
        _auditStore = auditStore;
        _auditEventFactory = auditEventFactory;
    }

    public async Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default)
    {
        return await new AuditScope(
                store: _auditStore, 
                @event: await _auditEventFactory.CreateAuditEventAsync(cancellationToken))
            .StartAsync(cancellationToken);
    }
}