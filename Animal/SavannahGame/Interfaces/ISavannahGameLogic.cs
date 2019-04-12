using Entities.Animals;
using Entities.GameField;

namespace Savannah.Entities.SavannahGame.Implementation
{
    public interface ISavannahGameLogic
    {
        void PlaceAnimalOnRandomAndFreePosition(SavannahGameState gameField, IAnimal animal);
    }
}