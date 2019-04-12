using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Implementation;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Common;
using Savannah.Common.Facades;
using Savannah.Common.Factories;
using Savannah.Entities.Factories;
using Savannah.Entities.SavannahGame.Implementation;

namespace Application.AppStart.Dependencies
{
    public class DependencyInjectionContainer
    {
        public ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                    .AddTransient<IInputOutput, InputAndOutputForConsole>()
                    .AddTransient<ISavannahGameLoop, SavannahGameLoop>()
                    .AddTransient<IPositionOnFieldFactory, PositionOnFieldFactory>()
                    .AddTransient<ISavannahGameLogic, SavannahGameLogic>()
                    .AddTransient<ISavannahGameStateFactory, SavannahGameStateFactory>()
                    .AddTransient<IConfigurationFactory, ConfigurationFactory>()
                    .AddSingleton<IRandomiserFactory, RandomiserFactory>()
                    .AddTransient<IRandomiserFascade, RandomiserFascade>()
                    .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
