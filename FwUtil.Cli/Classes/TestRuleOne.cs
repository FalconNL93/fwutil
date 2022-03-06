using FwUtil.Core.Models;

namespace FwUtil.Cli.Classes;

public static class TestRuleOne
{
    public static readonly FirewallRule Rule = new()
    {
        Enabled = true,
        DisplayName = "FWUtil: Block Port 80 outgoing",
        Description = "Blocks any outgoing traffic to port 80",
        RemotePorts = "80",
        Action = FirewallRule.Actions.Block,
        Direction = FirewallRule.Directions.Outbound,
        Protocol = FirewallRule.Protocols.Tcp,
        InterfaceType = FirewallRule.InterfaceTypes.Any
    };
}