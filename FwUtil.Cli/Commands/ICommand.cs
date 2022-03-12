using FwUtil.Core.Services;

namespace FwUtil.Cli.Commands;

public interface ICommand
{
    public void Execute()
    {
    }

    public void Execute(FirewallService firewallService)
    {
    }
}