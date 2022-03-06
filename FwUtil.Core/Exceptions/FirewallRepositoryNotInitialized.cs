namespace FwUtil.Core.Exceptions;

public class FirewallRepositoryNotInitialized : Exception
{
    public FirewallRepositoryNotInitialized()
    {
    }

    public FirewallRepositoryNotInitialized(string message)
        : base(message)
    {
    }

    public FirewallRepositoryNotInitialized(string message, Exception inner)
        : base(message, inner)
    {
    }
}