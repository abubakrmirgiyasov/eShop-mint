using Mint.Application.Interfaces;

namespace Mint.Architecture.Tests.Operations.Commands;

public class MediatorCommandTests
{
    [Fact]
    public void ShouldHaveNameEndingWithCommand()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(ICommand))
            .Or()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }
}
