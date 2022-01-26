using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Events.WellKnown;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Incremental.Common.Metrics.Sinks.EntityFramework.Configuration;

public class BasicMetricEventConfiguration : IEntityTypeConfiguration<BasicMetricEvent>
{
    public void Configure(EntityTypeBuilder<BasicMetricEvent> builder)
    {
        builder.HasBaseType<MetricEvent>();
    }
}