using Microsoft.EntityFrameworkCore;

namespace Mint.Architecture.Tests.Configurations;

public class EntityTypeConfigurationTests
{
    [Fact]
    public void ShouldHaveNameEndingWithConfiguration()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(IEntityConfiguration<>))
            .Or()
            .ImplementInterface(typeof(IEntityConfiguration<,>))
            .Should()
            .HaveNameEndingWith("Configuration")
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }

    [Fact]
    public void ShouldResideInNamespaceContainingConfigurations()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(IEntityConfiguration<>))
            .Or()
            .ImplementInterface(typeof(IEntityConfiguration<,>))
            .Should()
            .ResideInNamespaceContaining("Configurations")
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }

    [Fact]
    public void ShouldBeDefinedInInfrastructureOnly()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(IEntityTypeConfiguration<>))
            .Should()
            .ResideInNamespaceStartingWith(typeof(ApplicationRef).Namespace)
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }

    [Fact]
    public void ShouldBeNotPublicAndBeSealed()
    {
        var result = InAssemblies(Utils.Architecture.Assemblies)
            .That()
            .AreClasses().And()
            .ImplementInterface(typeof(IEntityConfiguration<>))
            .Or()
            .ImplementInterface(typeof(IEntityConfiguration<,>))
            .Should()
            .NotBePublic().And().BeSealed()
            .GetResult();

        Utils.Architecture.AssertSuccessful(result);
    }
}
