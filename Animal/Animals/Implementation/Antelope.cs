using System;
using Entities.GameField;

namespace Entities.Animals.Implementation
{
    public class Antelope : IAnimal
    {
        public int VisionRange { get; set; }

        public PositionOnField PositionOnField { get; set; }

        public string Name { get; set; }

        public Antelope()
        {
            this.Name = "A";
            this.VisionRange = 5;
            this.PositionOnField = new PositionOnField();
        }

        public void Move(SavannahGameField gameField)
        {
            PositionOnField lionsPositionOnField = new PositionOnField();
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

        private void ChillAroundAndEatGrass()
        {
            throw new NotImplementedException();
        }

        //TO DO: Antilope tries to avoid Lion


        private PositionOnField GetLionsPositionOnField(SavannahGameField gameField)
    {
            PositionOnField LionsPositionOnField = new PositionOnField();
        for (int x = PositionOnField.XPosition - VisionRange; x < PositionOnField.XPosition + VisionRange; x++)
        {
            for (int y = PositionOnField.YPosition - VisionRange; y < PositionOnField.YPosition + VisionRange; y++)
            {
                if (gameField.SavannahField[x, y].Name == "L")
                {
                    LionsPositionOnField.XPosition = x;
                    LionsPositionOnField.YPosition = y;
                    return LionsPositionOnField;
                }
            }
        }
            LionsPositionOnField.IsInViewRange = false;
            return LionsPositionOnField;
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

    public void SpecialAction()
    {
        //TO DO: Antilopes Special Action is to run 5 blocks at a time at a  one out of 5 possibility
    }

    }
}
