using Entities.GameField;
using Savannah.Common;

namespace Savannah.Entities.Factories
{
    public interface ISavannahGameStateFactory
    {
        SavannahGameState GetNewSavannahGameState(IConfigurationFactory configurationFactory);
    }
}