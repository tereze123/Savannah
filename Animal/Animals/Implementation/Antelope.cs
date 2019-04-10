using System;
using Entities.Animals.Enums;
using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        public string Name { get; set; }

        public int VisionRange { get; set; }

        public PositionOnField PositionOnField { get; set; }

        private PositionOnField lionsPositionOnField;

        private readonly Random rand;

        public Antelope()
        {
            this.lionsPositionOnField = new PositionOnField();
            this.Name = "A";
            this.VisionRange = 2;
            this.PositionOnField = new PositionOnField();
            this.rand = new Random(); ;
        }

        public void PeaceStateMovement(ISavannahGameField gameField)
        {
            lionsPositionOnField = this.GetLionsPositionOnField(gameField);
            if (lionsPositionOnField.IsInViewRange)
            {
                this.ActionWhenSeesEnenmy(lionsPositionOnField, gameField);
            }
            else
            {
                this.ChillAround(gameField);
            }
        }

        private void ChillAround(ISavannahGameField gameField)
        {
            int gameSize = gameField.SavannahField.GetLength(0);
            int existingRowPositionOnField = this.PositionOnField.RowPosition;
            int existingColumnPositionOnField = this.PositionOnField.ColumnPosition;
            int randomMovement = rand.Next(1, 5);
            MovementWay movementWay = (MovementWay)randomMovement;

            int tempChangedRowPosition = this.PositionOnField.RowPosition;
            int tempChangedColumnPosition = this.PositionOnField.ColumnPosition;
            switch (movementWay)
            {
                case MovementWay.Up:
                    tempChangedColumnPosition = (this.PositionOnField.ColumnPosition + 1 +  gameSize) % gameSize;
                    break;
                case MovementWay.Down:
                    tempChangedColumnPosition = (this.PositionOnField.ColumnPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Left:
                    tempChangedRowPosition = (this.PositionOnField.RowPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Right:
                    tempChangedRowPosition = (this.PositionOnField.RowPosition + 1 + gameSize) % gameSize;
                    break;
                default:
                    throw new ArgumentException();
            }
            if (gameField.SavannahField[tempChangedRowPosition, tempChangedColumnPosition] == null)
            {
                this.PositionOnField.RowPosition = tempChangedRowPosition;
                this.PositionOnField.ColumnPosition = tempChangedColumnPosition;
                this.ChangePositionOnField(gameField, existingRowPositionOnField, existingColumnPositionOnField);
            }
        }

        private void ChangePositionOnField(ISavannahGameField gameField, int lastRowPositionOnField, int lastColumnPositionOnField)
        {
            gameField.SavannahField[lastRowPositionOnField, lastColumnPositionOnField] = null;
            gameField.SavannahField[this.PositionOnField.RowPosition, this.PositionOnField.ColumnPosition] = this;
        }

        //Set looparound the field
        private PositionOnField GetLionsPositionOnField(ISavannahGameField gameField)
        {
            int antilopesRowPosition = this.PositionOnField.RowPosition;
            int antilopesColumnPosition = this.PositionOnField.ColumnPosition;
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
                            lionsPositionOnField.RowPosition = x;
                            lionsPositionOnField.ColumnPosition = y;
                            lionsPositionOnField.IsInViewRange = true;
                            return lionsPositionOnField;
                        }
                    }
                }
            }
            return lionsPositionOnField;
        }

        public void ActionWhenSeesEnenmy(PositionOnField lionsPositionOnField, ISavannahGameField gameField)
        {
            int existingRowPositionOnField = this.PositionOnField.RowPosition;
            int existingColumnPositionOnField = this.PositionOnField.ColumnPosition;
            int gameSize = gameField.SavannahField.GetLength(0);
            int tempChangedRowPosition = this.PositionOnField.RowPosition;
            int tempChangedColumnPosition = this.PositionOnField.ColumnPosition;

            if (this.PositionOnField.RowPosition > lionsPositionOnField.RowPosition)
            {
                tempChangedRowPosition = this.PositionOnField.RowPosition = (this.PositionOnField.RowPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedRowPosition = (this.PositionOnField.RowPosition - 2 + gameSize) % gameSize;
            }

            if (this.PositionOnField.ColumnPosition > lionsPositionOnField.ColumnPosition)
            {
                tempChangedColumnPosition = (this.PositionOnField.ColumnPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedColumnPosition = (this.PositionOnField.ColumnPosition - 2 + gameSize) % gameSize;
            }
            if (gameField.SavannahField[tempChangedRowPosition, tempChangedColumnPosition] == null)
                ChangePositionOnField(gameField, existingRowPositionOnField, existingColumnPositionOnField);
        }
    }
}
