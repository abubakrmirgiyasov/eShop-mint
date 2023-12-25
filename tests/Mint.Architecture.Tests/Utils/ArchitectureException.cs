namespace Mint.Architecture.Tests.Utils;

public class ArchitectureException(IEnumerable<string> failingTypesNames) 
    : Exception(GetMessage(failingTypesNames))
{
    private static string GetMessage(IEnumerable<string> failingTypesNames)
    {
        string message = "Нарушение архитектуры.\nНайдены нарушения в следующих типах:\n";
        message += string.Join("\n", failingTypesNames);
        return message;
    }
}
