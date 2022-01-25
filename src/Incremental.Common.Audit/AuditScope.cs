namespace Incremental.Common.Audit;

public class AuditScope : IAuditScope
{
    private bool _disposed;

    public AuditScope()
    {
        _disposed = false;
    }
    protected internal async Task<AuditScope> StartAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult(this);
    }

    public async Task CancelAsync()
    {
        await DisposeAsync();
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;
    }
}