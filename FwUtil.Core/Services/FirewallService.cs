using FwUtil.Core.Converters;
using FwUtil.Core.Exceptions;
using FwUtil.Core.Models;
using FwUtil.Core.Repositories;
using NetFwTypeLib;

namespace FwUtil.Core.Services;

public class FirewallService
{
    private readonly FirewallRepository _repository;

    protected FirewallService()
    {
        try
        {
            _repository = new FirewallRepository();
        }
        catch (Exception e)
        {
            throw new FirewallRepositoryNotInitialized(e.Message, e);
        }
    }

    public List<FirewallRule> Rules()
    {
        return (from INetFwRule item in _repository.Rules() select FirewallRuleConverter.ConvertFrom(item))
            .ToList();
    }

    public List<FirewallRule> Rules(Predicate<FirewallRule> match)
    {
        return Rules().FindAll(match);
    }

    public void AddRule(FirewallRule firewallRule)
    {
        //if (Rules().Exists(r => r.DisplayName == firewallRule.DisplayName)) throw new FirewallRuleAlreadyExists();

        _repository.AddRule(FirewallRuleConverter.ConvertTo(firewallRule));
    }

    public void RemoveRule(FirewallRule firewallRule)
    {
        if (!Rules().Exists(r => r.DisplayName == firewallRule.DisplayName)) throw new FirewallRuleNotFoundException();

        _repository.RemoveRule(FirewallRuleConverter.ConvertTo(firewallRule));
    }

    public bool Exists(FirewallRule firewallRule)
    {
        return Rules().Exists(r => r.DisplayName == firewallRule.DisplayName);
    }

    public bool Exists(Predicate<FirewallRule> match)
    {
        return Rules().Exists(match);
    }

    public bool DisableFirewall()
    {
        return _repository.DisableFirewall();
    }

    public bool EnableFirewall()
    {
        return _repository.EnableFirewall();
    }
}