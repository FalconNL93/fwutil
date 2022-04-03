using NetFwTypeLib;

namespace FwUtil.Core.Classes;

public class NetFwRule2 : INetFwRule2
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string ApplicationName { get; set; }

    public string serviceName { get; set; }

    public int Protocol { get; set; }

    public string LocalPorts { get; set; } = "";

    public string RemotePorts { get; set; } = "";

    public string LocalAddresses { get; set; } = "";

    public string RemoteAddresses { get; set; } = "";

    public string IcmpTypesAndCodes { get; set; }

    public NET_FW_RULE_DIRECTION_ Direction { get; set; }

    public object Interfaces { get; set; }

    public string InterfaceTypes { get; set; }

    public bool Enabled { get; set; }

    public string Grouping { get; set; }

    public int Profiles { get; set; }

    public bool EdgeTraversal { get; set; }

    public NET_FW_ACTION_ Action { get; set; }

    public int EdgeTraversalOptions { get; set; }
}