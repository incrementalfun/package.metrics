namespace Incremental.Common.Metrics.Options;

public class MetricOptions
{
    public static string Metrics => "Metrics";

    public MetricOptions()
    {
        ThrowOnAuditException = false;
    }

    public bool ThrowOnAuditException { get; set; }
}