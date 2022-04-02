using FwUtil.Core.Models;

namespace FwUtil.Cli.Extensions;

public static class FirewallRuleExtensions
{
    public static IEnumerable<FirewallRule> InboundRules(this IEnumerable<FirewallRule> firewallRules,
        FirewallRule.Protocols protocol)
    {
        return firewallRules.Where(x => x.Direction == FirewallRule.Directions.Inbound)
            .Where(x => x.Protocol == protocol);
    }

    public static IEnumerable<FirewallRule> OutboundRules(this IEnumerable<FirewallRule> firewallRules,
        FirewallRule.Protocols protocol)
    {
        return firewallRules.Where(x => x.Direction == FirewallRule.Directions.Outbound)
            .Where(x => x.Protocol == protocol);
    }

    public static IEnumerable<FirewallRule> EnabledRules(this IEnumerable<FirewallRule> firewallRules)
    {
        return firewallRules.Where(x => x.Enabled);
    }

    public static IEnumerable<FirewallRule> DisabledRules(this IEnumerable<FirewallRule> firewallRules)
    {
        return firewallRules.Where(x => !x.Enabled);
    }
}