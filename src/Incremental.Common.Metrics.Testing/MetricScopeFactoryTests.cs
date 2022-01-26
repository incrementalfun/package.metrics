using System.Threading.Tasks;
using Incremental.Common.Metrics.Events;
using Incremental.Common.Metrics.Events.WellKnown;
using Incremental.Common.Metrics.Sink;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Metrics.Testing;

public class MetricScopeFactoryTests
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
    public async Task Creates_MetricScope()
    {
        var metricScope = await _metricScopeFactory.CreateScopeAsync<BasicMetricEvent>("testEvent");
        
        Assert.IsNotNull(metricScope);
    }
    
    [Test]
    public async Task Creates_MetricScope_With_Generic_MetricEvent()
    {
        await using (var unused = await _metricScopeFactory.CreateScopeAsync<TestingMetricEvent>("testEvent"))
        {
            
        }
        
        _metricSinkMock.Verify(m => m.SaveAsync(It.IsAny<TestingMetricEvent>(), default));
    }

    private sealed class TestingMetricEvent : MetricEvent { }
}