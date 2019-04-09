using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using System;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        private readonly ISavannahGameField gameField; 
        private readonly IInputOutput inputOutput; 
        private readonly Random random; 
        private PositionOnField randomPosition; 

        public SavannahEngine( ISavannahGameField gameField, IInputOutput inputOutput)
        {
            this.gameField = gameField;
            this.inputOutput = inputOutput;
            this.random = new Random();
            this.randomPosition = new PositionOnField();
        }

        public void Start()
        {
            inputOutput.DrawGameField(gameField);
            string keyPressedByUser;
            keyPressedByUser = inputOutput.ReturnKeyPressed();
            if (keyPressedByUser == "A") { this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, new Antelope()); }
            else if (keyPressedByUser == "L") { this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, new Lion()); }
        }

        private PositionOnField GetRandomPositionOnField(ISavannahGameField gameField)
        {
            int gameFieldSize = gameField.SavannahField.GetLength(0);
            randomPosition.XPosition = random.Next(0, gameFieldSize);
            randomPosition.YPosition = random.Next(0, gameFieldSize);
            return randomPosition;
        }

        private void PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(ISavannahGameField gameField, IAnimal animal)
        {
            do
            {
                randomPosition = GetRandomPositionOnField();
            } while (gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] != null);
            gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] = animal;
            inputOutput.DrawGameField(gameField);
        }
    }
}
