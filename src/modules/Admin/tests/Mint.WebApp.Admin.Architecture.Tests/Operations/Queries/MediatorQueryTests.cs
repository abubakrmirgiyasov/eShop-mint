using Mint.Application.Interfaces;

namespace Mint.Architecture.Tests.Operations.Queries;

public class MediatorQueryTests
{
    [Fact]
    public void ShouldHaveNameEndingWithQuery()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(IQuery<>))
            .Or()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }
}
