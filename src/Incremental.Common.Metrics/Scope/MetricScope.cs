using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Sink;

namespace Incremental.Common.Metrics.Scope;

public class MetricScope<TAuditEvent> : IMetricScope where TAuditEvent : MetricEvent
{
    private readonly IMetricSink _sink;
    private readonly TAuditEvent _event;

    private CancellationToken _cancellationToken;
    private bool _disposed;
    private bool _cancelled;

    public MetricScope(IMetricSink sink, TAuditEvent @event)
    {
        _sink = sink;
        _event = @event;

        _disposed = false;
        _cancelled = false;
    }
    protected internal async Task<MetricScope<TAuditEvent>> StartAsync(CancellationToken cancellationToken = default)
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