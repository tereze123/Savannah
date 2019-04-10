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
            this.VisionRange = 5;
            this.PositionOnField = new PositionOnField();
            this.rand = new Random(); ;
        }

        public void ActionWhenSeesEnenmy(PositionOnField lionsPositionOnField,ISavannahGameField gameField)
        {
            throw new NotImplementedException();
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
            int existingXPositionOnField = this.PositionOnField.XPosition;
            int existingYPositionOnField = this.PositionOnField.YPosition;
            int randomMovement = rand.Next(1, 5);
            MovementWay movementWay = (MovementWay)randomMovement;

            switch (movementWay)
            {
                case MovementWay.Up:
                    this.PositionOnField.YPosition += 1;
                    break;
                case MovementWay.Down:
                    this.PositionOnField.YPosition -= 1;
                    break;
                case MovementWay.Left:
                    this.PositionOnField.XPosition -= 1;
                    break;
                case MovementWay.Right:
                    this.PositionOnField.XPosition += 1;
                    break;
                default:
                    throw new ArgumentException();
            }
            ChangePositionOnField(gameField, existingXPositionOnField, existingYPositionOnField);
        }

        private void ChangePositionOnField(ISavannahGameField gameField, int lastXPositionOnField, int lastYPositionOnField)
        {
            gameField.SavannahField[lastXPositionOnField, lastYPositionOnField] = null;
            gameField.SavannahField[this.PositionOnField.XPosition, this.PositionOnField.YPosition] = this;
        }

        //Set looparound the field
        private PositionOnField GetLionsPositionOnField(ISavannahGameField gameField)
        {
            var gameSize = gameField.SavannahField.GetLength(0);
            for (int x = (VisionRange * - 1); x <  VisionRange; x++)
            {
                for (int y = (VisionRange * -1); y < + VisionRange; y++)
                {
                    var row = (x + this.PositionOnField.XPosition + gameSize) % gameSize;
                    var column = (y + this.PositionOnField.YPosition + gameSize) % gameSize;
                    if(gameField.SavannahField[row, column].Name != null)
                    {

                    if (gameField.SavannahField[row, column].Name == "L")
                    {
                        lionsPositionOnField.XPosition = row;
                        lionsPositionOnField.YPosition = column;
                        return lionsPositionOnField;
                    }

                    }
                }
            }
        lionsPositionOnField.IsInViewRange = false;
        return lionsPositionOnField;
        }

        private void RunAwayFromLion(PositionOnField lionsPositionOnField)
        {

        if (this.PositionOnField.XPosition > lionsPositionOnField.XPosition)
        {
            this.PositionOnField.XPosition += 2;
        }
        else
        {
            this.PositionOnField.XPosition -= 2;
        }

        if (this.PositionOnField.YPosition > lionsPositionOnField.YPosition)
        {
            this.PositionOnField.YPosition += 2;
        }
        else
        {
            this.PositionOnField.YPosition -= 2;
        }
    }
    }
}
