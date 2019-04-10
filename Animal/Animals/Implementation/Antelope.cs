using System;
using Entities.Animals.Enums;
using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        private readonly Random rand;

        public Antelope():base()
        {
            this.Name = "A";
            this.VisionRange = 2;
            this.rand = new Random(); ;
        }

        public override void PeaceStateMovement(ISavannahGameField gameField)
        {
            PositionOnFieldOfEnemy = this.GetLionsPositionOnField(gameField);
            if (PositionOnFieldOfEnemy.IsInViewRange)
            {
                this.ActionWhenSeesEnenmy(PositionOnFieldOfEnemy, gameField);
            }
            else
            {
                this.ChillAround(gameField);
            }
        }

        private void ChillAround(ISavannahGameField gameField)
        {
            int gameSize = gameField.SavannahField.GetLength(0);
            int existingRowPositionOnField = this.AnimalsPositionOnField.RowPosition;
            int existingColumnPositionOnField = this.AnimalsPositionOnField.ColumnPosition;
            int randomMovement = rand.Next(1, 5);
            MovementWay movementWay = (MovementWay)randomMovement;

            int tempChangedRowPosition = this.AnimalsPositionOnField.RowPosition;
            int tempChangedColumnPosition = this.AnimalsPositionOnField.ColumnPosition;
            switch (movementWay)
            {
                case MovementWay.Up:
                    tempChangedColumnPosition = (this.AnimalsPositionOnField.ColumnPosition + 1 +  gameSize) % gameSize;
                    break;
                case MovementWay.Down:
                    tempChangedColumnPosition = (this.AnimalsPositionOnField.ColumnPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Left:
                    tempChangedRowPosition = (this.AnimalsPositionOnField.RowPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Right:
                    tempChangedRowPosition = (this.AnimalsPositionOnField.RowPosition + 1 + gameSize) % gameSize;
                    break;
                default:
                    throw new ArgumentException();
            }
            if (gameField.SavannahField[tempChangedRowPosition, tempChangedColumnPosition] == null)
            {
                this.AnimalsPositionOnField.RowPosition = tempChangedRowPosition;
                this.AnimalsPositionOnField.ColumnPosition = tempChangedColumnPosition;
                this.ChangePositionOnField(gameField, existingRowPositionOnField, existingColumnPositionOnField);
            }
        }

        private void ChangePositionOnField(ISavannahGameField gameField, int lastRowPositionOnField, int lastColumnPositionOnField)
        {
            gameField.SavannahField[lastRowPositionOnField, lastColumnPositionOnField] = null;
            gameField.SavannahField[this.AnimalsPositionOnField.RowPosition, this.AnimalsPositionOnField.ColumnPosition] = this;
        }

        //Set looparound the field
        private PositionOnField GetLionsPositionOnField(ISavannahGameField gameField)
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

        public override void ActionWhenSeesEnenmy(PositionOnField lionsPositionOnField, ISavannahGameField gameField)
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
