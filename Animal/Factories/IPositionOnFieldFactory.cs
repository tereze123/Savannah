using Entities.GameField;

namespace Savannah.Entities.Factories
{
    public interface IPositionOnFieldFactory
    {
        PositionOnField GetNewEmptyPositionOnField();
        PositionOnField GetNewPositionOnFieldWithKnownCoordinates(PositionOnField knownPositionOnField);
        PositionOnField GetRandomPositionOnField(int gameFieldSize);
    }
}