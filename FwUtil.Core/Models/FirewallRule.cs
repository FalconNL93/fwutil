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
    }

    public enum Protocols
    {
        Tcp,
        Udp,
        Any,
        Unknown
    }

    public bool Enabled { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public string? LocalPort { get; set; }
    public string? RemotePort { get; set; }
    public Actions Action { get; set; }
    public Directions Direction { get; set; }
    public Protocols Protocol { get; set; }
    public string? Program { get; set; }
    public string? Grouping { get; set; }
    public InterfaceTypes InterfaceType { get; set; }
}