using Entities.Animals;

namespace Entities.GameField
{
    public interface ISavannahGameField
    {
        IAnimal[,] SavannahField { get; set; }
    }
}