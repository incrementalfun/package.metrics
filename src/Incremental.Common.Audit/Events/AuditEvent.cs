namespace Incremental.Common.Audit.Events;

public class AuditEvent
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    
    public AuditEvent()
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