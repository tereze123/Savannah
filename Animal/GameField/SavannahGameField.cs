using Entities.Animals;

namespace Entities.GameField
{
    public class SavannahGameField : ISavannahGameField
    {
        public IAnimal[,] SavannahField { get; set; }

        public SavannahGameField()
        {
            this.SavannahField = new IAnimal[20,20];
        }        
    }
}
