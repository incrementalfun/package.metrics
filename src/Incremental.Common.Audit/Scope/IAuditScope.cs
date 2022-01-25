namespace Incremental.Common.Audit.Scope;

public interface IAuditScope : IAsyncDisposable
{
    public Task CancelAsync();
}