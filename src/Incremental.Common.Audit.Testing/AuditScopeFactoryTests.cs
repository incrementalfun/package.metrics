using System.Threading.Tasks;
using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Store;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryTests
{
    private IAuditScopeFactory _auditScopeFactory = null!;
    private readonly Mock<IAuditStore> _auditStoreMock = new();

    [SetUp]
    public void Setup()
    {
        _auditScopeFactory = new AuditScopeFactory(
            logger: new NullLogger<AuditScopeFactory>(),
            auditStore: _auditStoreMock.Object,
            auditEventFactory: new AuditEventFactory());
    }

    [Test]
    public async Task Creates_AuditScope()
    {
        var auditScope = await _auditScopeFactory.CreateScopeAsync("testEvent");
        
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