using Entities.GameField;
using Savannah.Common;

namespace Savannah.Entities.Factories
{
    public class SavannahGameStateFactory : ISavannahGameStateFactory
    {
        public SavannahGameState GetNewSavannahGameState(IConfigurationFactory configurationFactory)
        {
            return new SavannahGameState(configurationFactory);
        }
    }
}
