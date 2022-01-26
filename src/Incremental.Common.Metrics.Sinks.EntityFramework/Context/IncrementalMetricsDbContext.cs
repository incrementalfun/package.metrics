using Incremental.Common.Metrics.Sinks.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Incremental.Common.Metrics.Sinks.EntityFramework.Context;

public class IncrementalMetricsDbContext : DbContext
{
    protected IncrementalMetricsDbContext()
    {
    }

    public IncrementalMetricsDbContext(DbContextOptions<IncrementalMetricsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetricEventConfiguration).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}