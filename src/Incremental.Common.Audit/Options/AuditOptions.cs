namespace Incremental.Common.Audit.Options;

public class AuditOptions
{
    public static string Audit => "Audit";

    public AuditOptions()
    {
        ThrowOnAuditException = false;
    }

    public bool ThrowOnAuditException { get; set; }
}