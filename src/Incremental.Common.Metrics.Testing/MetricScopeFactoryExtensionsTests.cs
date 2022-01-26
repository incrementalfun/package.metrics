using System.Threading.Tasks;
using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Events.WellKnown;
using Incremental.Common.Metrics.Extensions;
using Incremental.Common.Metrics.Sink;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Metrics.Testing;

public class MetricScopeFactoryExtensionsTests
{
    private IMetricScopeFactory _metricScopeFactory = null!;
    private readonly Mock<IMetricSink> _metricSinkMock = new();

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();

        services.AddLogging();

        services.AddTransient<IMetricEventFactory, MetricEventFactory>();
        services.AddTransient(typeof(IMetricSink), _ => _metricSinkMock.Object);
        services.AddTransient<IMetricScopeFactory, MetricScopeFactory>();
        
        var provider = services.BuildServiceProvider();

        _metricScopeFactory = provider.GetRequiredService<IMetricScopeFactory>();
    }

    [Test]
    public async Task Creates_MetricScope_With_Default_Event()
    {
        await using (var unused = await _metricScopeFactory.CreateScopeAsync("testEvent"))
        {
            
        }
        
        _metricSinkMock.Verify(m => m.SaveAsync(It.IsAny<BasicMetricEvent>(), default));
    }
}