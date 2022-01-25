using System.Threading.Tasks;
using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Events.WellKnown;
using Incremental.Common.Audit.Extensions;
using Incremental.Common.Audit.Sink;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryExtensionsTests
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
    public async Task Creates_AuditScope_With_Default_Event()
    {
        await using (var unused = await _auditScopeFactory.CreateScopeAsync("testEvent"))
        {
            
        }
        
        _auditStoreMock.Verify(m => m.SaveAsync(It.IsAny<BasicAuditEvent>(), default));
    }
}