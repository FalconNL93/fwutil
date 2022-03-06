using FwUtil.Core.Classes;
using FwUtil.Core.Exceptions;
using NetFwTypeLib;

namespace FwUtil.Core.Repositories;

internal class FirewallRepository
{
    private const string FwInstanceId = "HNetCfg.FwPolicy2";
    private readonly INetFwPolicy2 _firewall;

    public FirewallRepository()
    {
        Type firewallInstance = null;

        try
        {
            firewallInstance = Type.GetTypeFromProgID(FwInstanceId);

            if (firewallInstance == null)
                throw new NetFwException($"Instance {FwInstanceId} could not be initialized");
        }
        catch (Exception e)
        {
            throw new FirewallNotInitialized(e.Message, e);
        }

        _firewall = (INetFwPolicy2) Activator.CreateInstance(firewallInstance);
    }

    public INetFwRules Rules()
    {
        return _firewall.Rules;
    }

    public void AddRule(NetFwRule2 rule)
    {
        _firewall.Rules.Add(rule);
    }

    public void RemoveRule(NetFwRule2 rule)
    {
        _firewall.Rules.Remove(rule.Name);
    }
}