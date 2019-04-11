using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Lion : IAnimal
    {

        public PositionOnField PositionOnField { get; set; }

        public Lion()
        {
            this.Name = "L";
            this.VisionRange = 7;
            this.PositionOnField = new PositionOnField();
        }

        public override void PeaceStateMovement(SavannahGameState gameField)
        {
            throw new System.NotImplementedException();
        }

        public override void ActionWhenSeesEnenmy(PositionOnField PositionOnFieldOfTheEnemy, SavannahGameState gameField)
        {
            throw new System.NotImplementedException();
        }
    }
}
