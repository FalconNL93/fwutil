using FwUtil.Cli.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Extensions;

public static class ServiceCollectionExtensions
{
    public static int RegisterCommand<T1, T2>(this IServiceCollection serviceCollection, T1 commandOptions)
        where T1 : class where T2 : class, ICommand
    {
        serviceCollection.AddSingleton(commandOptions);
        serviceCollection.AddSingleton<ICommand, T2>();

        return 0;
    }
}