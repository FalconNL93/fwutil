using FwUtil.Core.Converters;
using FwUtil.Core.Exceptions;
using FwUtil.Core.Models;
using NetFwTypeLib;

namespace FwUtil.Core.Classes;

public class FirewallAction
{
    private readonly FirewallApi _firewallApi;
    private NetFwRule2 _firewallNetRule;

    public FirewallRule FirewallRule
    {
        get => FirewallRuleConverter.ConvertFrom(_firewallNetRule);
        set => _firewallNetRule = FirewallRuleConverter.ConvertTo(value);
    }

    public FirewallAction()
    {
        _firewallApi = new FirewallApi();
    }

    public void Add()
    {
        try
        {
            Item();
            throw new FirewallRuleAlreadyExists();
        }
        catch (FirewallRuleNotFoundException)
        {
            _firewallApi.Firewall.Rules.Add(_firewallNetRule);
        }
    }

    public void Remove()
    {
        try
        {
            Item();
            _firewallApi.Firewall.Rules.Remove(_firewallNetRule.Name);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public FirewallRule Item()
    {
        try
        {
            return FirewallRuleConverter.ConvertFrom(_firewallApi.Firewall.Rules.Item(_firewallNetRule.Name));
        }
        catch (FileNotFoundException)
        {
            throw new FirewallRuleNotFoundException();
        }
    }

    public IEnumerable<FirewallRule> Items()
    {
        return (from INetFwRule item in _firewallApi.Firewall.Rules select FirewallRuleConverter.ConvertFrom(item))
            .ToList();
    }
}