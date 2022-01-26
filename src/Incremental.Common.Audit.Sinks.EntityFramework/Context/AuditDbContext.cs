using Microsoft.EntityFrameworkCore;

namespace Incremental.Common.Audit.Sinks.EntityFramework.Context;

public class AuditDbContext : DbContext
{
    protected AuditDbContext()
    {
    }

    public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkAuditSink).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}