using System.Reflection;

namespace Mint.Infrastructure;

public static class ApplicationRef
{
    public static Assembly Assembly => typeof(ApplicationRef).Assembly;
}
