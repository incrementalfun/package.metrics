namespace Incremental.Common.Metrics.Scope;

public interface IMetricScope : IAsyncDisposable
{
    public Task CancelAsync();
}