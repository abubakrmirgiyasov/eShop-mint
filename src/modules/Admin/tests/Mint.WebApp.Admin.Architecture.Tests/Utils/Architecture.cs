using System.Reflection;

namespace Mint.Architecture.Tests.Utils;

public static class Architecture
{
    public static readonly Assembly[] Assemblies =
    {
        ApplicationRef.Assembly
    };

    public static void AssertSuccessful(TestResult result)
    {
        if (result.IsSuccessful)
            return;

        throw new ArchitectureException(result.FailingTypeNames);
    }
}
