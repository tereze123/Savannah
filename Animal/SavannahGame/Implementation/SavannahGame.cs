using Entities.Animals;

namespace Entities.GameField
{
    public class SavannahGameState
    {
        public int CountOfAnimalsOnField { get; set; }
        public IAnimal[,] SavannahField { get; set; }
    }
}
