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
            for (int x = PositionOnField.XPosition - VisionRange; x < PositionOnField.XPosition + VisionRange; x++)
            {
                for (int y = PositionOnField.YPosition - VisionRange; y < PositionOnField.YPosition + VisionRange; y++)
                {
                    if (gameField.SavannahField[x, y].Name == "L")
                    {
                        this.RunAwayFromLion();
                    }
                }
            }
            //TO DO: Antilope tries to avoid Lion
        }

        private void RunAwayFromLion()
        {
            var random = new Random();
            var movesToMake = random.Next(1, 4);

        }

        public void SpecialAction()
        {
            //TO DO: Antilopes Special Action is to run 5 blocks at a time at a  one out of 5 possibility
        }
    }
}
