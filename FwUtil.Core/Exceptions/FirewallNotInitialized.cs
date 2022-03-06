namespace FwUtil.Core.Exceptions;

public class FirewallNotInitialized : Exception
{
    public FirewallNotInitialized()
    {
    }

    public FirewallNotInitialized(string message)
        : base(message)
    {
    }

    public FirewallNotInitialized(string message, Exception inner)
        : base(message, inner)
    {
    }
}