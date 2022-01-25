namespace Incremental.Common.Audit;

public interface IAuditScopeFactory
{
    Task<IAuditScope> CreateScopeAsync(CancellationToken cancellationToken = default);
}