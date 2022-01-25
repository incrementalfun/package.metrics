using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Sink;

namespace Incremental.Common.Audit.Scope;

public class AuditScope<TAuditEvent> : IAuditScope where TAuditEvent : AuditEvent
{
    private readonly IAuditSink _sink;
    private readonly TAuditEvent _event;

    private CancellationToken _cancellationToken;
    private bool _disposed;
    private bool _cancelled;

    public AuditScope(IAuditSink sink, TAuditEvent @event)
    {
        _sink = sink;
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
            await _sink.SaveAsync(_event, _cancellationToken);
        }
    }
}