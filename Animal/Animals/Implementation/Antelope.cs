using System;
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
            int distanceBetweenLionAndAntilopeRow = positionOfEnemy.RowPosition - AnimalsPositionOnField.RowPosition;
            int distanceBetweenLionAndAntilopeColumn = positionOfEnemy.ColumnPosition - AnimalsPositionOnField.ColumnPosition;


            PositionOnField nextPositionOnField = new PositionOnField();
            nextPositionOnField.ColumnPosition = AnimalsPositionOnField.ColumnPosition;
            nextPositionOnField.RowPosition = AnimalsPositionOnField.RowPosition + 1;

            if (distanceBetweenLionAndAntilopeRow > 0)
            {
                nextPositionOnField.RowPosition -= 1;
            }
            else if(distanceBetweenLionAndAntilopeRow < 0)
            {
                nextPositionOnField.RowPosition += 1;
            }
            if (distanceBetweenLionAndAntilopeColumn > 0)
            {
                nextPositionOnField.ColumnPosition -= 1;
            }
            else if (distanceBetweenLionAndAntilopeColumn < 0)
            {
                nextPositionOnField.ColumnPosition += 1;
            }

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
            nextPositionOnField.ColumnPosition = AnimalsPositionOnField.ColumnPosition;
            nextPositionOnField.RowPosition = AnimalsPositionOnField.RowPosition;
            MovementWay movementWay = new MovementWay();

            do
            {
                if (CantMoveAnymore(newGenerationArray))
                {
                    nextPositionOnField = AnimalsPositionOnField;
                    break;
                }
                movementWay = this.GetRandomMovementWay();
                nextPositionOnField = this.Move(movementWay);
            } while (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField));

            //AnimalsPositionOnField.RowPosition = nextPositionOnField.RowPosition;
            //AnimalsPositionOnField.ColumnPosition = nextPositionOnField.ColumnPosition;
            return nextPositionOnField;
        }

        private bool CantMoveAnymore(IAnimal[,] newGenerationArray)
        {
            PositionOnField nextPositionOnField = new PositionOnField();
            nextPositionOnField.RowPosition = AnimalsPositionOnField.RowPosition;
            nextPositionOnField.ColumnPosition = AnimalsPositionOnField.ColumnPosition;

            int testRow = nextPositionOnField.RowPosition;
            int testCol = nextPositionOnField.ColumnPosition;

            int waysCantMoveCount = 0;

            if(CantMoveToTop(nextPositionOnField,newGenerationArray))
            {
                waysCantMoveCount += 1;
            }
            if (CantMoveDown(nextPositionOnField, newGenerationArray))
            {
                waysCantMoveCount += 1;
            }
            if (CantMoveToRight(nextPositionOnField, newGenerationArray))
            {
                waysCantMoveCount += 1;
            }
            if (CantMoveToLeft(nextPositionOnField, newGenerationArray))
            {
                waysCantMoveCount += 1;
            }

            if (waysCantMoveCount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CantMoveToTop(PositionOnField nextPositionOnField, IAnimal[,] newGenerationArray)
        {
            nextPositionOnField.RowPosition -= 1;

            if (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CantMoveToRight(PositionOnField nextPositionOnField, IAnimal[,] newGenerationArray)
        {
            nextPositionOnField.ColumnPosition += 1;

            if (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CantMoveDown(PositionOnField nextPositionOnField, IAnimal[,] newGenerationArray)
        {
            nextPositionOnField.RowPosition += 1;

            if (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CantMoveToLeft(PositionOnField nextPositionOnField, IAnimal[,] newGenerationArray)
        {
            nextPositionOnField.ColumnPosition -= 1;

            if (ThisPlaceInArrayIsTaken(newGenerationArray, nextPositionOnField) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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
