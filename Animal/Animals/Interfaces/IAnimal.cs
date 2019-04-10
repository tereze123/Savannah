using Entities.GameField;

namespace Entities.Animals
{
    public interface IAnimal
    {
        PositionOnField PositionOnField { get; set; }

        string Name { get; set; }

        int VisionRange { get; set; }

        void PeaceStateMovement(ISavannahGameField gameField);

        void ActionWhenSeesEnenmy(PositionOnField PositionOnFieldOfTheEnemy,ISavannahGameField gameField);
    }
}
