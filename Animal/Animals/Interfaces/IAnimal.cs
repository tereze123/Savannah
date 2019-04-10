using Entities.GameField;

namespace Entities.Animals
{
    //japarveido uz abstraktu klasi lai var konstruktora pielimet jaunu positiononfield un name
    public interface IAnimal
    {
        PositionOnField PositionOnField { get; set; }

        string Name { get; set; }

        int VisionRange { get; set; }

        void PeaceStateMovement(ISavannahGameField gameField);

        void ActionWhenSeesEnenmy(PositionOnField PositionOnFieldOfTheEnemy,ISavannahGameField gameField);
    }
}
