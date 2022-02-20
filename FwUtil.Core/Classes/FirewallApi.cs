using NetFwTypeLib;

namespace FwUtil.Core.Classes;

internal class FirewallApi
{
    public readonly INetFwPolicy2 Firewall;

    public FirewallApi()
    {
        Type firewallInstance = null;

        try
        {
            firewallInstance = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");

            if (firewallInstance == null) throw new Exception();
        }
        catch (Exception)
        {
            Environment.Exit(1);
        }

        Firewall = (INetFwPolicy2) Activator.CreateInstance(firewallInstance);
    }
}