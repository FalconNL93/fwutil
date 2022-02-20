namespace FwUtil.Core.Exceptions;

using System;

public class FirewallRuleAlreadyExists : Exception
{
    public FirewallRuleAlreadyExists()
    {
    }

    public FirewallRuleAlreadyExists(string message)
        : base(message)
    {
    }

    public FirewallRuleAlreadyExists(string message, Exception inner)
        : base(message, inner)
    {
    }
}