using Entities.Animals;
using Entities.GameField;

namespace Savannah.Application.GameEngine
{
    public interface ISavannahGameLoop
    {
        IAnimal[,] LoopTheGame(SavannahGameState savannahGameState);
        void UsersTurnToAddAnimals(SavannahGameState savannahGameState);
    }
}