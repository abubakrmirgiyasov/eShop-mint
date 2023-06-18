namespace Mint.WebApp.Telegram.WebHook.Extensions;

public static class MulticastDelegateExtensions
{
    public static IEnumerable<Task>? InvokeAll<T>(this T? multicastDelegate, Func<T, Task> invocationFunc)
        where T : MulticastDelegate
    {
        return multicastDelegate?
            .GetInvocationList()
            .Cast<T>()
            .Select(invocationFunc.Invoke)
            .ToArray();
    }    
}
