using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace Mint.WebApp.Admin.Tests.Utils;

public static class FixtureExtensions
{
    public static IFixture WithAutoNSubstitutions(this IFixture fixture)
        => fixture.Customize(new AutoNSubstituteCustomization());
}
