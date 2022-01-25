using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Incremental.Common.Audit.Testing;

public class AuditScopeFactoryTests
{
    private IAuditScopeFactory _auditScopeFactory;
    [SetUp]
    public void Setup()
    {
        _auditScopeFactory = new AuditScopeFactory(new NullLogger<AuditScopeFactory>());
    }

    [Test]
    public async Task Creates_AuditScope()
    {
        var auditScope = await _auditScopeFactory.CreateScopeAsync();
        
        Assert.IsNotNull(auditScope);
    }
}