using _03.BarrackWars.Core;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;
using Microsoft.Extensions.DependencyInjection;
using System;


public class AppEntryPoint
{
    static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureService();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
        IRunnable engine = new Engine(commandInterpreter);
        engine.Run();
    }

    private static IServiceProvider ConfigureService()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<IUnitFactory, UnitFactory>();
        services.AddSingleton<IRepository, UnitRepository>();
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}