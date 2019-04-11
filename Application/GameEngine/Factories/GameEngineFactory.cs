using Application.AppStart.Dependencies;
using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;

namespace Application.GameEngine.Factories
{
    public class GameEngineFactory
    {
        public SavannahEngine GetNewGameEngine()
        {
            DependencyInjectionContainer dependencyInjectionContainer = new DependencyInjectionContainer();
            ServiceProvider serviceProvider = dependencyInjectionContainer.GetServiceProvider();

            var gameField = serviceProvider.GetRequiredService<SavannahGameState>();
            var inputAndOuput = serviceProvider.GetRequiredService<IInputOutput>();
            return new SavannahEngine(gameField, inputAndOuput);
        }
    }
}
