using System.Threading.Tasks;
using Incremental.Common.Audit.Store;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryTests
{
    private IAuditScopeFactory _auditScopeFactory = null!;
    
    [SetUp]
    public void Setup()
    {
        _auditScopeFactory = new AuditScopeFactory(
            logger: new NullLogger<AuditScopeFactory>(),
            auditStore: new Mock<IAuditStore>().Object);
    }

    [Test]
    public async Task Creates_AuditScope()
    {
        var auditScope = await _auditScopeFactory.CreateScopeAsync();
        
        Assert.IsNotNull(auditScope);
    }
}