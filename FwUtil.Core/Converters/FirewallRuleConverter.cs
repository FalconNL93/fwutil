using FwUtil.Core.Classes;
using FwUtil.Core.Models;
using NetFwTypeLib;

namespace FwUtil.Core.Converters;

public static class FirewallRuleConverter
{
    public static NetFwRule2 ConvertTo(FirewallRule firewallRule)
    {
        var netFwRule2 = new NetFwRule2
        {
            Name = firewallRule.DisplayName,
            Description = firewallRule.Description,
            Direction = firewallRule.Direction switch
            {
                FirewallRule.Directions.Inbound => NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN,
                FirewallRule.Directions.Outbound => NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT,
                _ => throw new ArgumentOutOfRangeException()
            },
            Enabled = firewallRule.Enabled,
            Grouping = firewallRule.Grouping,
            Protocol = firewallRule.Protocol switch
            {
                FirewallRule.Protocols.Tcp => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP,
                FirewallRule.Protocols.Udp => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP,
                FirewallRule.Protocols.Any => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY,
                _ => throw new ArgumentOutOfRangeException()
            },
            LocalPorts = string.IsNullOrEmpty(firewallRule.LocalPort) ? null : firewallRule.LocalPort,
            RemotePorts = string.IsNullOrEmpty(firewallRule.RemotePort) ? null : firewallRule.RemotePort,
            Action = firewallRule.Action switch
            {
                FirewallRule.Actions.Allow => NET_FW_ACTION_.NET_FW_ACTION_ALLOW,
                FirewallRule.Actions.Block => NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                FirewallRule.Actions.MaximumTraffic => NET_FW_ACTION_.NET_FW_ACTION_MAX,
                _ => throw new ArgumentOutOfRangeException()
            },
            Profiles = (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL
        };

        return netFwRule2;
    }

    public static FirewallRule ConvertFrom(INetFwRule rule)
    {
        return new FirewallRule
        {
            DisplayName = rule.Name,
            Enabled = rule.Enabled,
            Description = rule.Description,
            Grouping = rule.Grouping,
            LocalPort = rule.LocalPorts,
            RemotePort = rule.RemotePorts,
            Action = rule.Action switch
            {
                NET_FW_ACTION_.NET_FW_ACTION_BLOCK => FirewallRule.Actions.Block,
                NET_FW_ACTION_.NET_FW_ACTION_ALLOW => FirewallRule.Actions.Allow,
                NET_FW_ACTION_.NET_FW_ACTION_MAX => FirewallRule.Actions.MaximumTraffic,
                _ => throw new ArgumentOutOfRangeException()
            },
            Direction = rule.Direction switch
            {
                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN => FirewallRule.Directions.Inbound,
                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT => FirewallRule.Directions.Outbound,
                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_MAX => FirewallRule.Directions.Inbound,
                _ => throw new ArgumentOutOfRangeException()
            },
            Protocol = rule.Protocol switch
            {
                (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP => FirewallRule.Protocols.Tcp,
                (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP => FirewallRule.Protocols.Udp,
                (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY => FirewallRule.Protocols.Any,
                _ => FirewallRule.Protocols.Unknown
            },
            Program = null,
            InterfaceType = FirewallRule.InterfaceTypes.Any,
        };
    }
}