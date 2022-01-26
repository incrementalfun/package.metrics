using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Sink;
using Incremental.Common.Audit.Sinks.EntityFramework.Context;
using Microsoft.Extensions.Logging;

namespace Incremental.Common.Audit.Sinks.EntityFramework;

public class EntityFrameworkAuditSink : IAuditSink
{
    private readonly ILogger<EntityFrameworkAuditSink> _logger;
    private readonly AuditDbContext _auditDbContext;

    public EntityFrameworkAuditSink(ILogger<EntityFrameworkAuditSink> logger, AuditDbContext auditDbContext)
    {
        _logger = logger;
        _auditDbContext = auditDbContext;
    }

    public async Task SaveAsync<TAuditEvent>(TAuditEvent @event, CancellationToken cancellationToken = default) 
        where TAuditEvent : AuditEvent
    {
        await _auditDbContext.Set<TAuditEvent>().AddAsync(@event, cancellationToken);

        await _auditDbContext.SaveChangesAsync(cancellationToken);
    }
}