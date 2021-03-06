namespace Incremental.Common.Metrics.Events;

public abstract class MetricEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }

    protected MetricEvent()
    {
        Id = Guid.NewGuid();
    }

    public void Start()
    {
        StartDate = DateTime.UtcNow;
    }

    public void End()
    {
        EndDate = DateTime.UtcNow;
        Duration = (EndDate - StartDate).Duration().Milliseconds;
    }
}