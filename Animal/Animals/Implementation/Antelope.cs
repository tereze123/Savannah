using System;
using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        public string Name { get; set; }

        public int VisionRange { get; set; }

        public PositionOnField PositionOnField { get; set; }

        public PositionOnField LionsPositionOnField { get; set; }

        public Antelope()
        {
            LionsPositionOnField = new PositionOnField();
            this.Name = "A";
            this.VisionRange = 5;
            this.PositionOnField = new PositionOnField();
        }

        public void SpecialAction()
    {
        //TO DO: Antilopes Special Action is to run 5 blocks at a time at a  one out of 5 possibility
    }

        public void Move(ISavannahGameField gameField)
        {
            lionsPositionOnField = this.GetLionsPositionOnField(gameField);
            if (lionsPositionOnField.IsInViewRange)
            {
                this.RunAwayFromLion(lionsPositionOnField);
            }
            else
            {
                this.ChillAroundAndEatGrass();
            }            
        }

        private PositionOnField lionsPositionOnField;
        
        private void ChillAroundAndEatGrass()
        {
            throw new NotImplementedException();
        }
        //TO DO: Antilope tries to avoid Lion

        private PositionOnField GetLionsPositionOnField(ISavannahGameField gameField)
    {
        for (int x = PositionOnField.XPosition - VisionRange; x < PositionOnField.XPosition + VisionRange; x++)
        {
            for (int y = PositionOnField.YPosition - VisionRange; y < PositionOnField.YPosition + VisionRange; y++)
            {
                if (gameField.SavannahField[x, y].Name == "L")
                {
                        lionsPositionOnField.XPosition = x;
                        lionsPositionOnField.YPosition = y;
                    return lionsPositionOnField;
                }
            }
        }
            lionsPositionOnField.IsInViewRange = false;
            return lionsPositionOnField;
    }

        private void RunAwayFromLion(PositionOnField lionsPositionOnField)
    {
        //if this.PositionOnField.XPosition > xPositionOfLion dont move back

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
        //if this.PositionOnField.XPosition < xPositionOfLion dont move forward
    }
    }
}
