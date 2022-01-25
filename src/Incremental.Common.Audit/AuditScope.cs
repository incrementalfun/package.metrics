namespace Incremental.Common.Audit;

public class AuditScope : IAuditScope
{
    protected internal async Task<AuditScope> StartAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult(this);
    }

    public async Task CancelAsync()
    {
        throw new NotImplementedException();
    }
    
    public async ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}