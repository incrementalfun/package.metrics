using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Events.WellKnown;
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

    public async Task<IAuditScope> CreateScopeAsync<TAuditEvent>(CancellationToken cancellationToken = default) 
        where TAuditEvent : AuditEvent, new()
    {
        return await new AuditScope<TAuditEvent>(
                store: _auditStore, 
                @event: await _auditEventFactory.CreateAuditEventAsync<TAuditEvent>(cancellationToken))
            .StartAsync(cancellationToken);
    }
    
    public async Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default)
    {
        return await CreateScopeAsync<BasicAuditEvent>(cancellationToken);
    }
}