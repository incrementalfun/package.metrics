using System.Runtime.Serialization;

namespace Incremental.Common.Metrics.Exceptions;

public class IncrementalMetricsException : Exception
{
    public IncrementalMetricsException()
    {
    }

    protected IncrementalMetricsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public IncrementalMetricsException(string? message) : base(message)
    {
    }

    public IncrementalMetricsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}