using Entities.Animals;
using Entities.GameField;
using Savannah.Common;
using Savannah.Entities.Factories;

namespace Savannah.Entities.SavannahGame.Implementation
{
    public class SavannahGameLogic : ISavannahGameLogic
    {
        private PositionOnField _randomPosition;
        private readonly IConfigurationFactory _configurationFactory;
        private readonly IPositionOnFieldFactory _positionOnFieldFactory;
        private readonly int _gameFieldSize;

        public SavannahGameLogic(PositionOnFieldFactory positionOnFieldFactory, IConfigurationFactory configurationFactory)
        {
            _configurationFactory = configurationFactory;
            _gameFieldSize = _configurationFactory.GetFieldSizeFromConfigurationFile();
            _randomPosition = positionOnFieldFactory.GetRandomPositionOnField(_gameFieldSize);
            _positionOnFieldFactory = positionOnFieldFactory;
        }

        #region SavannahGameGameLogic AddNewAnimalToField  
        public void PlaceAnimalOnRandomAndFreePosition(SavannahGameState gameField, IAnimal animal)
        {
            PositionOnField positionOnField = GetRandomAndFreePositionOnField(gameField);
            gameField.GameField[positionOnField.RowPosition, positionOnField.ColumnPosition] = animal;
            gameField.CountOfAnimalsOnField++;
            SetAnimalPositionProperties(animal, positionOnField);
        }

        private PositionOnField GetRandomAndFreePositionOnField(SavannahGameState gameField)
        {
            do
            {
                _randomPosition = _positionOnFieldFactory.GetRandomPositionOnField(_gameFieldSize);
            }while(!(CanAnimalMoveToThisLocation(_randomPosition, gameField)));
            return _randomPosition;
        }

        private bool CanAnimalMoveToThisLocation(PositionOnField positionOnField, SavannahGameState gameField)
        {
            if (IsThisFieldCellFree(positionOnField, gameField) && AreThereAnyFreeSpacesOnFieldLeft(gameField))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsThisFieldCellFree(PositionOnField positionOnField, SavannahGameState gameField)
        {
            if (gameField.GameField[positionOnField.RowPosition, positionOnField.ColumnPosition] != null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        private bool AreThereAnyFreeSpacesOnFieldLeft(SavannahGameState gameField)
        {
            if (gameField.CountOfAnimalsOnField == _gameFieldSize * _gameFieldSize)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetAnimalPositionProperties(IAnimal animal, PositionOnField positionOnField)
        {
            animal.AnimalsPositionOnField.RowPosition = positionOnField.RowPosition;
            animal.AnimalsPositionOnField.ColumnPosition = positionOnField.ColumnPosition;
        }
        #endregion

    }
}
