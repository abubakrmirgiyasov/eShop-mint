using System.Reflection;

namespace Mint.WebApp.Client.Application;

public class ClientApplicationRef
{
    public static Assembly Assembly => typeof(ClientApplicationRef).Assembly;
}
