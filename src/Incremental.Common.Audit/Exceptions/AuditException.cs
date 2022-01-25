using System.Runtime.Serialization;

namespace Incremental.Common.Audit.Exceptions;

public class AuditException : Exception
{
    public AuditException()
    {
    }

    protected AuditException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AuditException(string? message) : base(message)
    {
    }

    public AuditException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}