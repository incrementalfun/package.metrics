using Microsoft.Extensions.Logging;

namespace Incremental.Common.Audit;

public class AuditScopeFactory : IAuditScopeFactory
{
    private readonly ILogger<AuditScopeFactory> _logger;

    public AuditScopeFactory(ILogger<AuditScopeFactory> logger)
    {
        _logger = logger;
    }

    public async Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default)
    {
        return await new AuditScope().StartAsync(cancellationToken);
    }
}