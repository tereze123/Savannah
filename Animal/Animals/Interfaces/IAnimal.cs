using Entities.GameField;

namespace Entities.Animals
{
    //japarveido uz abstraktu klasi lai var konstruktora pielimet jaunu positiononfield un name
    public abstract class IAnimal
    {
        public IAnimal()
        {
            AnimalsPositionOnField = new PositionOnField();
            PositionOnFieldOfEnemy = new PositionOnField();
        }
        public PositionOnField AnimalsPositionOnField { get; set; }

        public PositionOnField PositionOnFieldOfEnemy { get; set; }

        public string Name { get; set; }

        public int VisionRange { get; set; }

        public abstract void  PeaceStateMovement(ISavannahGameField gameField);

        public abstract void ActionWhenSeesEnenmy(PositionOnField PositionOnFieldOfTheEnemy,ISavannahGameField gameField);
    }
}
