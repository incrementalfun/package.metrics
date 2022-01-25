using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Store;

namespace Incremental.Common.Audit;

public class AuditScope : IAuditScope
{
    private readonly IAuditStore _store;
    private readonly AuditEvent _event;
    
    private bool _disposed;
    private bool _cancelled;

    public AuditScope(IAuditStore store, AuditEvent @event)
    {
        _store = store;
        _event = @event;

        _disposed = false;
        _cancelled = false;
    }
    protected internal async Task<AuditScope> StartAsync(CancellationToken cancellationToken)
    {
        _event.Start();
        return await Task.FromResult(this);
    }

    public async Task CancelAsync()
    {
        _cancelled = true;
        await DisposeAsync();
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;

        if (!_cancelled)
        {
            _event.End();
            await _store.SaveAsync(_event);
        }
    }
}