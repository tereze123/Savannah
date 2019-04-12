using Entities.Animals.Enums;
using Entities.GameField;
using Savannah.Common.Facades;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        private readonly IRandomiserFascade randomiserFascade;

        public Antelope(IRandomiserFascade randomiserFascade)
        {
            Name = "A";
            VisionRange = 1;
            this.randomiserFascade = randomiserFascade;
        }
        public override PositionOnField ActionWhenSeesEnenmy(ref IAnimal[,] newGenerationArray, PositionOnField positionOfEnemy)
        {
            PositionOnField nextPositionOnField = new PositionOnField();
            nextPositionOnField.ColumnPosition = AnimalsPositionOnField.ColumnPosition;
            nextPositionOnField.RowPosition = AnimalsPositionOnField.RowPosition + 1;

            if (!(this.ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField)))
            {
                AnimalsPositionOnField = nextPositionOnField;
            }

            return this.AnimalsPositionOnField;
        }

        public override PositionOnField GetEnemysPositionOnField(IAnimal[,] initialGameArray)
        {
            int gameFieldSize = initialGameArray.GetLength(0);
            PositionOnField enemiesPositionOnField = new PositionOnField();
            int newRow;
            int newCol;

            for (int rowNumber = (VisionRange * -1); rowNumber < VisionRange; rowNumber++)
            {
                for (int columnNumber = (VisionRange * -1); columnNumber < VisionRange; columnNumber++)
                {
                    newRow = rowNumber + AnimalsPositionOnField.RowPosition;
                    newCol = columnNumber + AnimalsPositionOnField.ColumnPosition;
                    if (NotOutOfBoundsAndNotMe(gameFieldSize, newRow, newCol))
                    {
                        if (initialGameArray[newRow, newCol] != null && initialGameArray[newRow, newCol].Name == "L")
                        {
                            enemiesPositionOnField.RowPosition = rowNumber + AnimalsPositionOnField.RowPosition;
                            enemiesPositionOnField.ColumnPosition = columnNumber + AnimalsPositionOnField.ColumnPosition;
                            enemiesPositionOnField.IsInViewRange = true;
                            return enemiesPositionOnField;
                        }

                    }
                }
            }
            return enemiesPositionOnField;
        }

        private bool NotOutOfBoundsAndNotMe(int gameFieldSize, int row, int colums)
        {
            if ((row >= 0 && colums >= 0) && (row < gameFieldSize && colums < gameFieldSize) && (row != AnimalsPositionOnField.RowPosition && colums != AnimalsPositionOnField.ColumnPosition) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override PositionOnField PeaceStateMovementNextPosition(ref IAnimal[,] initialGameArray, ref IAnimal[,] newGenerationArray)
        {
            PositionOnField nextPositionOnField = new PositionOnField();
            MovementWay movementWay = new MovementWay();

            do
            {
                movementWay = this.GetRandomMovementWay();
                nextPositionOnField = this.Move(movementWay);
            } while (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField));

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
