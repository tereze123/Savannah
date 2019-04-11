using Entities.Animals;

namespace Entities.GameField
{
    public interface ISavannahGame
    {
        int CountOfAnimalsOnField { get; set; }
        IAnimal[,] SavannahField { get; set; }
    }
}