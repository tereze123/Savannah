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
        }

        public void Move()
        {
            //TO DO: Antilope tries to avoid Lion
        }

        public void SpecialAction()
        {
            //TO DO: Antilopes Special Action is to run 2 blocks at a time at a  one out of 5 possibility
        }
    }
}
