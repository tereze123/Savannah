using Entities.GameField;
using Savannah.Common.Factories;
using System;

namespace Savannah.Entities.Factories
{
    public class PositionOnFieldFactory : IPositionOnFieldFactory
    {
        private readonly Random _randomiser;

        public PositionOnFieldFactory()
        {
            RandomiserFactory randomiserFactory= new RandomiserFactory();
            _randomiser = randomiserFactory.GetNewRandomiser();
        }

        public PositionOnField GetNewEmptyPositionOnField()
        {
            return new PositionOnField();
        }

        public PositionOnField GetRandomPositionOnField(int gameFieldSize)
        {
            PositionOnField randomPosition = new PositionOnField();
            randomPosition.RowPosition = _randomiser.Next(0, gameFieldSize);
            randomPosition.ColumnPosition = _randomiser.Next(0, gameFieldSize);
            return randomPosition;
        }

        public PositionOnField GetNewPositionOnFieldWithKnownCoordinates(PositionOnField knownPositionOnField)
        {
            PositionOnField positionOnField = new PositionOnField();
            positionOnField.RowPosition = knownPositionOnField.RowPosition;
            positionOnField.ColumnPosition = knownPositionOnField.ColumnPosition;
            return positionOnField;
        }
    }
}
