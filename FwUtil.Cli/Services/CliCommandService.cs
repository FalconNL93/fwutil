using FwUtil.Cli.Commands;

namespace FwUtil.Cli.Services;

public class CliCommandService
{
    public readonly HelpCommand HelpCommand = new();
    public readonly ShowRulesCommand ShowRules = new();
}