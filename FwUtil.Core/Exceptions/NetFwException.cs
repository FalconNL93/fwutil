namespace FwUtil.Core.Exceptions;

public class NetFwException : Exception
{
    public NetFwException()
    {
    }

    public NetFwException(string message)
        : base(message)
    {
    }

    public NetFwException(string message, Exception inner)
        : base(message, inner)
    {
    }
}