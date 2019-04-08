using Entities.Animals;

namespace Entities.GameField
{
    public class SavannahGameField
    {
        public Animal[,] SavannahField { get; set; }

        public SavannahGameField()
        {
            this.SavannahField = new Animal[20,20];
        }        
    }
}
