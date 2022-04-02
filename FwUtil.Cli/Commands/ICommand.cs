using FwUtil.Cli.Options;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Commands;

public interface ICommand
{
    public void Handle();
}