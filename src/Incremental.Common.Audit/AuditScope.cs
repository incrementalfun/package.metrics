using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Store;

namespace Incremental.Common.Audit;

public class AuditScope<TAuditEvent> : IAuditScope where TAuditEvent : AuditEvent
{
    private readonly IAuditStore _store;
    private readonly TAuditEvent _event;

    private CancellationToken _cancellationToken;
    private bool _disposed;
    private bool _cancelled;

    public AuditScope(IAuditStore store, TAuditEvent @event)
    {
        _store = store;
        _event = @event;

        _disposed = false;
        _cancelled = false;
    }
    protected internal async Task<AuditScope<TAuditEvent>> StartAsync(CancellationToken cancellationToken = default)
    {
        _cancellationToken = cancellationToken;
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
            await _store.SaveAsync(_event, _cancellationToken);
        }
    }
}