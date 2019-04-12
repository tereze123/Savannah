using Entities.Animals;
using Savannah.Common;
using System.Collections.Generic;

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
            AnimalCollection = new List<IAnimal>();
        }

        public int GameFieldSize { get;}

        public int CountOfAnimalsOnField { get; set; }

        public IAnimal[,] GameField { get; set; }

        public List<IAnimal> AnimalCollection { get; set; }

    }
}
