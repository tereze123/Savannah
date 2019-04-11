using Entities.Animals;
using Savannah.Common;

namespace Entities.GameField
{
    public class SavannahGameState
    {
        private readonly IConfigurationFactory _configurationFactory;

        public SavannahGameState(IConfigurationFactory configurationFactory)
        {
            _configurationFactory = configurationFactory;
            GameFieldSize = _configurationFactory.GetFieldSizeFromConfigurationFile();
            GameField = new IAnimal[GameFieldSize, GameFieldSize];
        }

        public int GameFieldSize { get;}

        public int CountOfAnimalsOnField { get; set; }

        public IAnimal[,] GameField { get; set; }

    }
}
