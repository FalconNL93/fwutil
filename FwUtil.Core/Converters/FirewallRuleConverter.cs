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
            LocalPorts = string.IsNullOrEmpty(firewallRule.LocalPorts) ? null : firewallRule.LocalPorts,
            RemoteAddresses = string.IsNullOrEmpty(firewallRule.RemoteAddresses) ? null : firewallRule.RemoteAddresses,
            RemotePorts = string.IsNullOrEmpty(firewallRule.RemotePorts) ? null : firewallRule.RemotePorts,
            LocalAddresses = string.IsNullOrEmpty(firewallRule.LocalAddresses) ? null : firewallRule.LocalAddresses,
            Action = firewallRule.Action switch
            {
                FirewallRule.Actions.Allow => NET_FW_ACTION_.NET_FW_ACTION_ALLOW,
                FirewallRule.Actions.Block => NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                FirewallRule.Actions.MaximumTraffic => NET_FW_ACTION_.NET_FW_ACTION_MAX,
                _ => throw new ArgumentOutOfRangeException()
            },
            Profiles = firewallRule.InterfaceType switch
            {
                FirewallRule.InterfaceTypes.Any => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL,
                FirewallRule.InterfaceTypes.Domain => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN,
                FirewallRule.InterfaceTypes.Private => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE,
                FirewallRule.InterfaceTypes.Public => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC,
                _ => throw new ArgumentOutOfRangeException()
            },
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
            LocalPorts = rule.LocalPorts,
            LocalAddresses = rule.LocalAddresses,
            RemotePorts = rule.RemotePorts,
            RemoteAddresses = rule.RemoteAddresses,
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
            InterfaceType = FirewallRule.InterfaceTypes.Any
        };
    }
}