using Incremental.Common.Metrics.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incremental.Common.Metrics.Sinks.EntityFramework.Configuration;

public class MetricEventConfiguration : IEntityTypeConfiguration<MetricEvent>
{
    public void Configure(EntityTypeBuilder<MetricEvent> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();
        
        builder.Property(e => e.EndDate)
            .IsRequired();

        builder.Property(e => e.Duration)
            .IsRequired();

        builder.HasIndex(e => e.Name);
    }
}