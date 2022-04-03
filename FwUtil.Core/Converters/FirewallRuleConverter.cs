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
            Interfaces = null,
            InterfaceTypes = null,
            Enabled = firewallRule.Enabled,
            Grouping = firewallRule.Grouping != null ? string.Join(",", firewallRule.Grouping) : "",
            Protocol = firewallRule.Protocol switch
            {
                FirewallRule.Protocols.Tcp => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP,
                FirewallRule.Protocols.Udp => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP,
                FirewallRule.Protocols.Any => (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY,
                _ => throw new ArgumentOutOfRangeException()
            },
            LocalPorts = firewallRule.LocalPorts != null ? string.Join(",", firewallRule.LocalPorts) : "*",
            LocalAddresses = firewallRule.LocalAddresses != null
                ? string.Join(",", string.Join(",", firewallRule.LocalAddresses))
                : "",
            RemotePorts = firewallRule.RemotePorts != null ? string.Join(",", firewallRule.RemotePorts) : "*",
            RemoteAddresses = firewallRule.RemoteAddresses != null
                ? string.Join(",", string.Join(",", firewallRule.RemoteAddresses))
                : "",
            IcmpTypesAndCodes = null,
            Action = firewallRule.Action switch
            {
                FirewallRule.Actions.Allow => NET_FW_ACTION_.NET_FW_ACTION_ALLOW,
                FirewallRule.Actions.Block => NET_FW_ACTION_.NET_FW_ACTION_BLOCK,
                FirewallRule.Actions.MaximumTraffic => NET_FW_ACTION_.NET_FW_ACTION_MAX,
                _ => throw new ArgumentOutOfRangeException
                {
                    HelpLink = null,
                    HResult = 0,
                    Source = null
                }
            },
            Profiles = firewallRule.InterfaceType switch
            {
                FirewallRule.InterfaceTypes.Any => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL,
                FirewallRule.InterfaceTypes.Domain => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN,
                FirewallRule.InterfaceTypes.Private => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE,
                FirewallRule.InterfaceTypes.Public => (int) NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC,
                _ => throw new ArgumentOutOfRangeException()
            },
            ApplicationName = firewallRule.Program,
            serviceName = firewallRule.ServiceName,
            EdgeTraversal = firewallRule.EdgeTraversal,
            EdgeTraversalOptions = 0
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
            Grouping = string.IsNullOrEmpty(rule.Grouping) ? Array.Empty<string>() : rule.Grouping.Split(","),
            LocalPorts = string.IsNullOrEmpty(rule.LocalPorts) ? Array.Empty<string>() : rule.LocalPorts.Split(","),
            LocalAddresses = string.IsNullOrEmpty(rule.LocalAddresses)
                ? Array.Empty<string>()
                : rule.LocalAddresses.Split(","),
            RemotePorts = string.IsNullOrEmpty(rule.RemotePorts) ? Array.Empty<string>() : rule.RemotePorts.Split(","),
            RemoteAddresses = string.IsNullOrEmpty(rule.RemoteAddresses)
                ? Array.Empty<string>()
                : rule.RemoteAddresses.Split(","),
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
            Program = rule.ApplicationName,
            InterfaceType = FirewallRule.InterfaceTypes.Any,
            ServiceName = rule.serviceName,
            EdgeTraversal = rule.EdgeTraversal
        };
    }
}