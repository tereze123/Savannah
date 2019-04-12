using Entities.Animals.Enums;
using Entities.GameField;
using Savannah.Common.Facades;

namespace Entities.Animals.Implementation
{
    public class Lion : IAnimal
    {
        private readonly IRandomiserFascade randomiserFascade;
        public Lion(IRandomiserFascade randomiserFascade)
        {
            this.Name = "L";
            this.VisionRange = 7;
            this.randomiserFascade = randomiserFascade;
        }

        public override PositionOnField ActionWhenSeesEnenmy(ref IAnimal[,] initialGameArray, PositionOnField positionOfEnemy)
        {
            //Do nothing
            return AnimalsPositionOnField;
        }

        public override PositionOnField GetEnemysPositionOnField(IAnimal[,] initialGameArray)
        {
            int gameFieldSize = initialGameArray.GetLength(0);
            PositionOnField enemiesPositionOnField = new PositionOnField();

            for (int rowNumber = 0; rowNumber < gameFieldSize; rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < gameFieldSize; columnNumber++)
                {
                    if (initialGameArray[rowNumber, columnNumber] != null && initialGameArray[rowNumber, columnNumber].Name == "A")
                    {
                        enemiesPositionOnField.RowPosition = rowNumber;
                        enemiesPositionOnField.ColumnPosition = columnNumber;
                        enemiesPositionOnField.IsInViewRange = true;
                        return enemiesPositionOnField;
                    }
                }
            }
            return enemiesPositionOnField;
        }

        public override PositionOnField PeaceStateMovementNextPosition(ref IAnimal[,] initialGameArray, ref IAnimal[,] nextGenerationArray)
        {
            PositionOnField nextPositionOnField = new PositionOnField();
            MovementWay movementWay = new MovementWay();

            do
            {
                movementWay = this.GetRandomMovementWay();
                nextPositionOnField = this.Move(movementWay);
            } while (ThisPlaceInArrayIsTaken(nextGenerationArray, nextPositionOnField));

            AnimalsPositionOnField.RowPosition = nextPositionOnField.RowPosition;
            AnimalsPositionOnField.ColumnPosition = nextPositionOnField.ColumnPosition;
            return nextPositionOnField;
        }

        private bool ThisPlaceInArrayIsTaken(IAnimal[,] initialGameArray, PositionOnField nextPositionOnField)
        {
            if (nextPositionOnField.RowPosition >= initialGameArray.GetLength(0) || nextPositionOnField.ColumnPosition >= initialGameArray.GetLength(0))
            {
                return true;
            }
            else if (nextPositionOnField.RowPosition < 0 || nextPositionOnField.ColumnPosition < 0)
            {
                return true;
            }
            else if (initialGameArray[nextPositionOnField.RowPosition, nextPositionOnField.ColumnPosition] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private PositionOnField Move(MovementWay movementWay)
        {
            PositionOnField nextPositionOnField = new PositionOnField();
            nextPositionOnField.ColumnPosition = this.AnimalsPositionOnField.ColumnPosition;
            nextPositionOnField.RowPosition = this.AnimalsPositionOnField.RowPosition;

            switch (movementWay)
            {
                case MovementWay.Up:
                    nextPositionOnField.RowPosition -= 1;
                    break;
                case MovementWay.Right:
                    nextPositionOnField.ColumnPosition += 1;
                    break;
                case MovementWay.Down:
                    nextPositionOnField.RowPosition += 1;
                    break;
                case MovementWay.Left:
                    nextPositionOnField.ColumnPosition -= 1;
                    break;
                default:
                    break;
            }
            return nextPositionOnField;
        }

        private MovementWay GetRandomMovementWay()
        {
            int temp = randomiserFascade.Next(1, 5);
            return (MovementWay)temp;
        }
    }
}
