using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Lion : IAnimal
    {
        public Lion()
        {
            this.Name = "L";
            this.VisionRange = 7;
        }

        public override PositionOnField ActionWhenSeesEnenmy(ref IAnimal[,] initialGameArray, PositionOnField positionOfEnemy)
        {
            throw new System.NotImplementedException();
        }

        public override PositionOnField GetEnemysPositionOnField(IAnimal[,] initialGameArray)
        {
            throw new System.NotImplementedException();
        }

        public override PositionOnField PeaceStateMovementNextPosition(ref IAnimal[,] initialGameArray, ref IAnimal[,] nextGenerationArray)
        {
            throw new System.NotImplementedException();
        }
    }
}
