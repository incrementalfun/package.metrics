using Incremental.Common.Metrics.Sink;
using Incremental.Common.Metrics.Sinks.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Metrics.Sinks.EntityFramework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureEntityFrameworkSink<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions) 
        where TContext : IncrementalMetricsDbContext
    {
        var temporal = new DbContextOptionsBuilder();
        dbContextOptions.Invoke(temporal);
        
        services.AddDbContext<TContext>(dbContextOptions);
        
        services.AddTransient<IMetricSink, EntityFrameworkMetricSink<TContext>>();

        return services;
    }
}