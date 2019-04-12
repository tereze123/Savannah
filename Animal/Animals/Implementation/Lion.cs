using System;
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
            this.VisionRange = 4;
            this.randomiserFascade = randomiserFascade;
        }

        public override PositionOnField ActionWhenSeesEnenmy(ref IAnimal[,] nextGenerationArray, PositionOnField positionOfEnemy)
        {
            int distanceBetweenLionAndAntilopeRow = positionOfEnemy.RowPosition - AnimalsPositionOnField.RowPosition;
            int distanceBetweenLionAndAntilopeColumn = positionOfEnemy.ColumnPosition - AnimalsPositionOnField.ColumnPosition;

            if (AnimalsPositionOnField.RowPosition < 0 || AnimalsPositionOnField.ColumnPosition < 0
    || AnimalsPositionOnField.RowPosition >= nextGenerationArray.GetLength(0)
    || AnimalsPositionOnField.ColumnPosition >= nextGenerationArray.GetLength(0))
            {
                throw new ArgumentException();
            }

            PositionOnField nextPositionOnField = new PositionOnField();
            nextPositionOnField.ColumnPosition = AnimalsPositionOnField.ColumnPosition;
            nextPositionOnField.RowPosition = AnimalsPositionOnField.RowPosition;

            for (int i = 0; i < 2; i++)
            {
                if (distanceBetweenLionAndAntilopeRow > 0)
                {
                    nextPositionOnField.RowPosition += 1;
                }
                else if (distanceBetweenLionAndAntilopeRow < 0)
                {
                    nextPositionOnField.RowPosition -= 1;
                }
                if (distanceBetweenLionAndAntilopeColumn > 0)
                {
                    nextPositionOnField.ColumnPosition += 1;
                }
                else if (distanceBetweenLionAndAntilopeColumn < 0)
                {
                    nextPositionOnField.ColumnPosition -= 1;
                }

                if (!(this.CantGoHere(nextGenerationArray, nextPositionOnField)))
                {
                    if (WillEatAntilope(nextGenerationArray, nextPositionOnField))
                    {
                        nextGenerationArray[nextPositionOnField.RowPosition, nextPositionOnField.ColumnPosition] = null;
                        nextGenerationArray[nextPositionOnField.RowPosition, nextPositionOnField.ColumnPosition] = this;
                    }
                    AnimalsPositionOnField.ColumnPosition = nextPositionOnField.ColumnPosition;
                    AnimalsPositionOnField.RowPosition = nextPositionOnField.RowPosition;
                }
                else
                {
                    return AnimalsPositionOnField;
                }
            }
            return AnimalsPositionOnField;
        }

        private bool WillEatAntilope(IAnimal[,] nextGenerationArray, PositionOnField nextPositionOnField)
        {
            if (nextGenerationArray[nextPositionOnField.RowPosition, nextPositionOnField.ColumnPosition] != null)
            {
                if (nextGenerationArray[nextPositionOnField.RowPosition, nextPositionOnField.ColumnPosition].Name == "A")
                {
                    return true;
                }
            }
            return false;
        }

        public override PositionOnField GetEnemysPositionOnField(ref IAnimal[,] initialGameArray)
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
            } while (CantGoHere(nextGenerationArray, nextPositionOnField));

            if (AnimalsPositionOnField.RowPosition < 0 || AnimalsPositionOnField.ColumnPosition < 0 || AnimalsPositionOnField.RowPosition >= nextGenerationArray.GetLength(0) || AnimalsPositionOnField.ColumnPosition >= nextGenerationArray.GetLength(0))
            {
                throw new ArgumentException();
            }
            return AnimalsPositionOnField;

            AnimalsPositionOnField.RowPosition = nextPositionOnField.RowPosition;
            AnimalsPositionOnField.ColumnPosition = nextPositionOnField.ColumnPosition;
            return nextPositionOnField;
        }

        private bool CantGoHere(IAnimal[,] initialGameArray, PositionOnField nextPositionOnField)
        {
            if (nextPositionOnField.RowPosition >= initialGameArray.GetLength(0) || nextPositionOnField.ColumnPosition >= initialGameArray.GetLength(0))
            {
                return true;
            }
            else if (nextPositionOnField.RowPosition < 0 || nextPositionOnField.ColumnPosition < 0)
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
