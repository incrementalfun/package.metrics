using System.Reflection;
using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Scope;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Metrics;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonMetrics(this IServiceCollection services)
    {
        services.AddTransient<IMetricEventFactory, MetricEventFactory>();
        services.AddTransient<IMetricScopeFactory, MetricScopeFactory>();

        return services;
    }

    public static IServiceCollection UseMetricEventFactoryConfigurationsFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        services.Scan(selector => selector.FromAssemblies(assembly)
            .AddClasses(filter => filter
                .AssignableTo(typeof(IMetricEventFactoryConfigurationHandler<>))));

        return services;
    }
}