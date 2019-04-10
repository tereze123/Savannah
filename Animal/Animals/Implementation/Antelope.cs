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
            int existingXPositionOnField = this.PositionOnField.XPosition;
            int existingYPositionOnField = this.PositionOnField.YPosition;
            int randomMovement = rand.Next(1, 5);
            MovementWay movementWay = (MovementWay)randomMovement;

            int tempChangedXPosition = this.PositionOnField.XPosition;
            int tempChangedYPosition = this.PositionOnField.YPosition;
            switch (movementWay)
            {
                case MovementWay.Up:
                    tempChangedYPosition = (this.PositionOnField.YPosition + 1 +  gameSize) % gameSize;
                    break;
                case MovementWay.Down:
                    tempChangedYPosition = (this.PositionOnField.YPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Left:
                    tempChangedXPosition = (this.PositionOnField.XPosition - 1 + gameSize) % gameSize;
                    break;
                case MovementWay.Right:
                    tempChangedXPosition = (this.PositionOnField.XPosition + 1 + gameSize) % gameSize;
                    break;
                default:
                    throw new ArgumentException();
            }
            if (gameField.SavannahField[tempChangedXPosition, tempChangedYPosition] == null)
            {
                this.PositionOnField.XPosition = tempChangedXPosition;
                this.PositionOnField.YPosition = tempChangedYPosition;
                this.ChangePositionOnField(gameField, existingXPositionOnField, existingYPositionOnField);
            }
        }

        private void ChangePositionOnField(ISavannahGameField gameField, int lastXPositionOnField, int lastYPositionOnField)
        {
            gameField.SavannahField[lastXPositionOnField, lastYPositionOnField] = null;
            gameField.SavannahField[this.PositionOnField.XPosition, this.PositionOnField.YPosition] = this;
        }

        //Set looparound the field
        private PositionOnField GetLionsPositionOnField(ISavannahGameField gameField)
        {
            int antilopesXPosition = this.PositionOnField.XPosition;
            int antilopesYPosition = this.PositionOnField.YPosition;
            var gameSize = gameField.SavannahField.GetLength(0);
            for (int i = (VisionRange * - 1); i < VisionRange + 1; i++)
            {
                for (int j = (VisionRange * -1); j < VisionRange + 1; j++)
                {
                    int row = (i + antilopesXPosition + gameSize) % gameSize;
                    int column = (j + antilopesYPosition + gameSize) % gameSize;

                    if (gameField.SavannahField[row, column] != null)
                    {
                        if ((gameField.SavannahField[row, column]).Name == "L")
                        {
                            lionsPositionOnField.XPosition = column;
                            lionsPositionOnField.YPosition = row ;
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
            int existingXPositionOnField = this.PositionOnField.XPosition;
            int existingYPositionOnField = this.PositionOnField.YPosition;
            int gameSize = gameField.SavannahField.GetLength(0);
            int tempChangedXPosition = this.PositionOnField.XPosition;
            int tempChangedYPosition = this.PositionOnField.YPosition;

            if (this.PositionOnField.XPosition > lionsPositionOnField.XPosition)
            {
                tempChangedXPosition = this.PositionOnField.XPosition = (this.PositionOnField.XPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedXPosition = (this.PositionOnField.XPosition - 2 + gameSize) % gameSize;
            }

            if (this.PositionOnField.YPosition > lionsPositionOnField.YPosition)
            {
                tempChangedYPosition = (this.PositionOnField.YPosition + 2 + gameSize) % gameSize;
            }
            else
            {
                tempChangedYPosition = (this.PositionOnField.YPosition - 2 + gameSize) % gameSize;
            }
            if (gameField.SavannahField[tempChangedXPosition, tempChangedYPosition] == null)
                ChangePositionOnField(gameField, existingXPositionOnField, existingYPositionOnField);
        }
    }
}
