using Entities.GameField;

namespace Entities.Animals
{

    public abstract class IAnimal
    {

        public string Name { get; set; }

        public int VisionRange { get; set; }

        public IAnimal()
        {
            AnimalsPositionOnField = new PositionOnField();
        }

        public PositionOnField AnimalsPositionOnField { get; set; }

        public abstract PositionOnField GetEnemysPositionOnField(ref IAnimal[,] initialGameArray);

        public abstract PositionOnField PeaceStateMovementNextPosition(ref IAnimal[,] newGenerationArray, ref IAnimal[,] nextGenerationArray);

        public abstract PositionOnField ActionWhenSeesEnenmy(ref IAnimal[,] initialGameArray, PositionOnField positionOfEnemy);
    }
}
