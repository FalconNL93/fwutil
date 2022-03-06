using NetFwTypeLib;

namespace FwUtil.Core.Classes;

public class NetFwPolicy2 : INetFwPolicy2
{
    public void EnableRuleGroup(int profileTypesBitmask, string group, bool enable)
    {
        throw new NotImplementedException();
    }

    public bool IsRuleGroupEnabled(int profileTypesBitmask, string group)
    {
        throw new NotImplementedException();
    }

    public void RestoreLocalFirewallDefaults()
    {
        throw new NotImplementedException();
    }

    public int CurrentProfileTypes { get; }

    public INetFwRules Rules { get; }

    public INetFwServiceRestriction ServiceRestriction { get; }

    public NET_FW_MODIFY_STATE_ LocalPolicyModifyState { get; }

    public bool get_IsRuleGroupCurrentlyEnabled(string group)
    {
        throw new NotImplementedException();
    }

    public void set_DefaultOutboundAction(NET_FW_PROFILE_TYPE2_ profileType, NET_FW_ACTION_ Action)
    {
        throw new NotImplementedException();
    }

    public NET_FW_ACTION_ get_DefaultOutboundAction(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_DefaultInboundAction(NET_FW_PROFILE_TYPE2_ profileType, NET_FW_ACTION_ Action)
    {
        throw new NotImplementedException();
    }

    public NET_FW_ACTION_ get_DefaultInboundAction(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_UnicastResponsesToMulticastBroadcastDisabled(NET_FW_PROFILE_TYPE2_ profileType, bool disabled)
    {
        throw new NotImplementedException();
    }

    public bool get_UnicastResponsesToMulticastBroadcastDisabled(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_NotificationsDisabled(NET_FW_PROFILE_TYPE2_ profileType, bool disabled)
    {
        throw new NotImplementedException();
    }

    public bool get_NotificationsDisabled(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_BlockAllInboundTraffic(NET_FW_PROFILE_TYPE2_ profileType, bool Block)
    {
        throw new NotImplementedException();
    }

    public bool get_BlockAllInboundTraffic(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_ExcludedInterfaces(NET_FW_PROFILE_TYPE2_ profileType, object Interfaces)
    {
        throw new NotImplementedException();
    }

    public object get_ExcludedInterfaces(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }

    public void set_FirewallEnabled(NET_FW_PROFILE_TYPE2_ profileType, bool Enabled)
    {
        throw new NotImplementedException();
    }

    public bool get_FirewallEnabled(NET_FW_PROFILE_TYPE2_ profileType)
    {
        throw new NotImplementedException();
    }
}