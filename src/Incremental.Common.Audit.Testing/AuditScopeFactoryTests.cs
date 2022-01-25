using System.Threading.Tasks;
using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Events.WellKnown;
using Incremental.Common.Audit.Sink;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryTests
{
    private IAuditScopeFactory _auditScopeFactory = null!;
    private readonly Mock<IAuditSink> _auditStoreMock = new();

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();

        services.AddLogging();

        services.AddTransient<IAuditEventFactory, AuditEventFactory>();
        services.AddTransient(typeof(IAuditSink), _ => _auditStoreMock.Object);
        services.AddTransient<IAuditScopeFactory, AuditScopeFactory>();
        
        var provider = services.BuildServiceProvider();

        _auditScopeFactory = provider.GetRequiredService<IAuditScopeFactory>();
    }

    [Test]
    public async Task Creates_AuditScope()
    {
        var auditScope = await _auditScopeFactory.CreateScopeAsync<BasicAuditEvent>("testEvent");
        
        Assert.IsNotNull(auditScope);
    }
    
    [Test]
    public async Task Creates_AuditScope_With_Generic_AuditEvent()
    {
        await using (var unused = await _auditScopeFactory.CreateScopeAsync<TestingAuditEvent>("testEvent"))
        {
            
        }
        
        _auditStoreMock.Verify(m => m.SaveAsync(It.IsAny<TestingAuditEvent>(), default));
    }

    private sealed class TestingAuditEvent : AuditEvent { }
}