using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Scope;
using Incremental.Common.Audit.Sink;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Audit;

public class AuditScopeFactory : IAuditScopeFactory
{
    private readonly ILogger<AuditScopeFactory> _logger;
    private readonly IAuditSink _auditSink;
    private readonly IAuditEventFactory _auditEventFactory;

    public AuditScopeFactory(ILogger<AuditScopeFactory> logger, IAuditSink auditSink, IAuditEventFactory auditEventFactory)
    {
        _logger = logger;
        _auditSink = auditSink;
        _auditEventFactory = auditEventFactory;
    }

    public async Task<IAuditScope> CreateScopeAsync<TAuditEvent>(string eventName, CancellationToken cancellationToken = default) 
        where TAuditEvent : AuditEvent, new()
    {
        return await new AuditScope<TAuditEvent>(
                sink: _auditSink, 
                @event: await _auditEventFactory.CreateAuditEventAsync<TAuditEvent>(eventName,cancellationToken))
            .StartAsync(cancellationToken);
    }
}