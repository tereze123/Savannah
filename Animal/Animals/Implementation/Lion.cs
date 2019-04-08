using System;

namespace Entities.Animals.Implementation
{
    public class Lion : IAnimal
    {
        public int VisionRange { get; set; }

        public void Move()
        {
            //TO DO: Implement Lion Move - Chase Antilope
        }

        public void SpecialAction()
        {
            //TO DO: Implement Lion SpecialAction - shoot lazors with one out of 10 possibility. Lazor range - 7 blocks. Damage - 3% of preys health
        }
    }
}
