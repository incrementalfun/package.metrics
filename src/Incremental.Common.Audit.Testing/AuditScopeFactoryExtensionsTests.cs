using System.Threading.Tasks;
using Incremental.Common.Audit.Events;
using Incremental.Common.Audit.Events.WellKnown;
using Incremental.Common.Audit.Extensions;
using Incremental.Common.Audit.Store;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryExtensionsTests
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
    public async Task Creates_AuditScope_With_Default_Event()
    {
        await using (var unused = await _auditScopeFactory.CreateScopeAsync("testEvent"))
        {
            
        }
        
        _auditStoreMock.Verify(m => m.SaveAsync(It.IsAny<BasicAuditEvent>(), default));
    }
}