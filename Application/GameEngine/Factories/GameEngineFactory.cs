using Application.AppStart.Dependencies;
using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Common;

namespace Application.GameEngine.Factories
{
    public class GameEngineFactory
    {
        public SavannahEngine GetNewGameEngine()
        {
            DependencyInjectionContainer dependencyInjectionContainer = new DependencyInjectionContainer();
            ServiceProvider serviceProvider = dependencyInjectionContainer.GetServiceProvider();

            var inputAndOuput = serviceProvider.GetRequiredService<IInputOutput>();
            var configfactory = new SavannahConfiguration();
            var gameState = new SavannahGameState(configfactory);
            
            var loopGame = new SavannahGameLoop(inputAndOuput, gameState, new Savannah.Entities.SavannahGame.Implementation.SavannahGameLogic(new Savannah.Entities.Factories.PositionOnFieldFactory(), configfactory));
            return new SavannahEngine(gameState, inputAndOuput, loopGame);
        }
    }
}
