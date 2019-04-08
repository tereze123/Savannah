using Entities.Animals;

namespace Entities.GameField
{
    public class SavannahGameField
    {
        public IAnimal[,] SavannahField { get; set; }

        public SavannahGameField()
        {
            this.SavannahField = new IAnimal[20,20];
        }        
    }
}
