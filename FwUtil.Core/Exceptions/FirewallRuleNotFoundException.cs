namespace FwUtil.Core.Exceptions;

using System;

public class FirewallRuleNotFoundException : Exception
{
    public FirewallRuleNotFoundException()
    {
    }

    public FirewallRuleNotFoundException(string message)
        : base(message)
    {
    }

    public FirewallRuleNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}