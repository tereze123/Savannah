using Application.AppStart.Dependencies;
using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Common;
using Savannah.Common.Facades;
using Savannah.Entities.Factories;

namespace Application.GameEngine.Factories
{
    public class GameEngineFactory
    {
        public SavannahEngine GetNewGameEngine()
        {
            DependencyInjectionContainer dependencyInjectionContainer = new DependencyInjectionContainer();
            ServiceProvider serviceProvider = dependencyInjectionContainer.GetServiceProvider();

            var inputAndOuput = serviceProvider.GetRequiredService<IInputOutput>();
            var loopGame = serviceProvider.GetRequiredService<ISavannahGameLoop>();
            var gameStateFactory = serviceProvider.GetRequiredService<ISavannahGameStateFactory>();
            var configfactory = serviceProvider.GetRequiredService<IConfigurationFactory>();
            var randomiserFascade = serviceProvider.GetRequiredService<IRandomiserFascade>();

            
            return new SavannahEngine(
                inputAndOuput,
                loopGame,
                gameStateFactory,
                configfactory,
                randomiserFascade);
        }
    }
}
