using System;
using Entities.Animals.Enums;
using Entities.GameField;
using Savannah.Entities.Factories;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        private readonly Random rand;
        private readonly PositionOnFieldFactory _positionOnFieldFactory;

        public Antelope() :base()
        {
            this.Name = "A";
            this.VisionRange = 2;
            this.rand = new Random(); ;
            _positionOnFieldFactory = new PositionOnFieldFactory();
        }

        public override void PeaceStateMovement(SavannahGameState gameField)
        {
            PositionOnFieldOfEnemy = this.GetLionsPositionOnField(gameField);

            if (PositionOnFieldOfEnemy.IsInViewRange)
            {
                this.ActionWhenSeesEnenmy(PositionOnFieldOfEnemy, gameField);
            }
            else
            {
                GetNextPossibleMoveOfAnimal(gameField);

            }
        }

        private PositionOnField GetNextPossibleMoveOfAnimal(SavannahGameState gameField)
        {
            PositionOnField nextGenerationPosition = _positionOnFieldFactory.GetNewPositionOnFieldWithKnownCoordinates(AnimalsPositionOnField);

            MovementWay movementWay = GetRandomDirection();

            switch (movementWay)
            {
                case MovementWay.Up:
                    nextGenerationPosition.RowPosition -=  1;
                    break;
                case MovementWay.Down:
                    nextGenerationPosition.RowPosition += 1;
                    break;
                case MovementWay.Left:
                    nextGenerationPosition.ColumnPosition -=  1;
                    break;
                case MovementWay.Right:
                    nextGenerationPosition.ColumnPosition += 1;
                    break;
                default:
                    throw new ArgumentException();
            }
            return nextGenerationPosition;
        }

        private MovementWay GetRandomDirection()
        {
            int randomMovement = rand.Next(1, 5);
            MovementWay movementWay = (MovementWay)randomMovement;
            return movementWay;
        }

        private void ChangePositionOnField(SavannahGameState gameField, int lastRowPositionOnField, int lastColumnPositionOnField)
        {
            gameField.SavannahField[lastRowPositionOnField, lastColumnPositionOnField] = null;
            gameField.SavannahField[this.AnimalsPositionOnField.ColumnPosition, this.AnimalsPositionOnField.RowPosition] = this;
        }

        //Set looparound the field
        private PositionOnField GetLionsPositionOnField(SavannahGameState gameField)
        {
            int antilopesRowPosition = this.AnimalsPositionOnField.RowPosition;
            int antilopesColumnPosition = this.AnimalsPositionOnField.ColumnPosition;
            var gameSize = gameField.SavannahField.GetLength(0);
            for (int i = (VisionRange * - 1); i < VisionRange + 1; i++)
            {
                for (int j = (VisionRange * -1); j < VisionRange + 1; j++)
                {
                    int x = (i + antilopesRowPosition + gameSize) % gameSize;
                    int y = (j + antilopesColumnPosition + gameSize) % gameSize;

                    if (gameField.SavannahField[x, y] != null)
                    {
                        if ((gameField.SavannahField[x, y]).Name == "L")
                        {
                            PositionOnFieldOfEnemy.RowPosition = x;
                            PositionOnFieldOfEnemy.ColumnPosition = y;
                            PositionOnFieldOfEnemy.IsInViewRange = true;
                            return PositionOnFieldOfEnemy;
                        }
                    }
                }
            }
            return PositionOnFieldOfEnemy;
        }

        public override void ActionWhenSeesEnenmy(PositionOnField lionsPositionOnField, SavannahGameState gameField)
        {
            int existingRowPositionOnField = this.AnimalsPositionOnField.RowPosition;
            int existingColumnPositionOnField = this.AnimalsPositionOnField.ColumnPosition;
            int gameSize = gameField.SavannahField.GetLength(0);
            int tempChangedRowPosition = this.AnimalsPositionOnField.RowPosition;
            int tempChangedColumnPosition = this.AnimalsPositionOnField.ColumnPosition;

            if (this.AnimalsPositionOnField.RowPosition > lionsPositionOnField.RowPosition)
            {
                tempChangedRowPosition = this.AnimalsPositionOnField.RowPosition = (this.AnimalsPositionOnField.RowPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedRowPosition = (this.AnimalsPositionOnField.RowPosition - 2 + gameSize) % gameSize;
            }

            if (this.AnimalsPositionOnField.ColumnPosition > lionsPositionOnField.ColumnPosition)
            {
                tempChangedColumnPosition = (this.AnimalsPositionOnField.ColumnPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedColumnPosition = (this.AnimalsPositionOnField.ColumnPosition - 2 + gameSize) % gameSize;
            }
            if (gameField.SavannahField[tempChangedRowPosition, tempChangedColumnPosition] == null)
                ChangePositionOnField(gameField, existingRowPositionOnField, existingColumnPositionOnField);
        }
    }
}
