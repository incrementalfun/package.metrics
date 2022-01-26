using Incremental.Common.Audit.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incremental.Common.Audit.Sinks.EntityFramework.Configuration;

public class AuditEventConfiguration : IEntityTypeConfiguration<AuditEvent>
{
    public void Configure(EntityTypeBuilder<AuditEvent> builder)
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