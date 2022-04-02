using FwUtil.Core.Models;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Extensions;

public static class LoggerExtensions
{
    public static void LogFirewallRulesCount(this ILogger logger, List<FirewallRule> firewallRules)
    {
        logger.LogInformation("Inbound: TCP Rules: {TcpRules} UDP Rules: {UdpRules}",
            firewallRules.InboundRules(FirewallRule.Protocols.Tcp).ToList().Count,
            firewallRules.InboundRules(FirewallRule.Protocols.Udp).ToList().Count);

        logger.LogInformation("Outbound: TCP Rules: {TcpRules} UDP Rules: {UdpRules}",
            firewallRules.OutboundRules(FirewallRule.Protocols.Tcp).ToList().Count,
            firewallRules.OutboundRules(FirewallRule.Protocols.Udp).ToList().Count);

        logger.LogInformation("Enabled: {Enabled} rules Disabled: {DisabledRules}",
            firewallRules.EnabledRules().ToList().Count,
            firewallRules.DisabledRules().ToList().Count);
    }
}