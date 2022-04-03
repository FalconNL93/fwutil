namespace FwUtil.Core.Models;

public class FirewallRule
{
    public enum Actions
    {
        Allow,
        Block,
        MaximumTraffic
    }

    public enum Directions
    {
        Inbound,
        Outbound
    }

    public enum InterfaceTypes
    {
        Any,
        Domain,
        Public,
        Private
    }

    public enum Protocols
    {
        Tcp,
        Udp,
        Any,
        Unknown
    }

    public bool Enabled { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string[] LocalPorts { get; set; }
    public string[] LocalAddresses { get; set; }
    public string[] RemotePorts { get; set; }
    public string[] RemoteAddresses { get; set; }
    public Actions Action { get; set; }
    public Directions Direction { get; set; }
    public Protocols Protocol { get; set; }
    public string Program { get; set; }
    public string[] Grouping { get; set; } = {"FWUtil"};
    public InterfaceTypes InterfaceType { get; set; }

    public string ServiceName { get; set; }
    public bool EdgeTraversal { get; set; }
}