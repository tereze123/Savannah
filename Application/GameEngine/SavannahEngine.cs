using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        public List<IAnimal> AnimalCollection { get; set; }
        private readonly ISavannahGameField gameField;
        private readonly IInputOutput inputOutput;
        private readonly Random random;
        private PositionOnField randomPosition;

        public SavannahEngine(ISavannahGameField gameField, IInputOutput inputOutput)
        {
            this.AnimalCollection = new List<IAnimal>();
            this.gameField = gameField;
            this.inputOutput = inputOutput;
            this.random = new Random();
            this.randomPosition = new PositionOnField();
        }

        public void Start()
        {
            inputOutput.DrawGameField(gameField);
            this.UsersTurnToAddAnimals();
            this.PlayGame();
        }

        private void PlayGame()
        {
            foreach (IAnimal animal in this.AnimalCollection)
            {
                animal.PeaceStateMovement(gameField);
            }
        }

        //TO be reconstructed
        private void UsersTurnToAddAnimals()
        {
            string keyPressedByUser;
            do
            {
                keyPressedByUser = inputOutput.ReturnKeyPressed();
                if (keyPressedByUser == "A")
                {
                    IAnimal antilope = new Antelope();
                    this.AnimalCollection.Add(antilope);
                    this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, antilope);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    this.AnimalCollection.Add(lion);
                    this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, lion);
                }
            } while (keyPressedByUser != "ESC");
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
                randomPosition = GetRandomPositionOnField(gameField);
            } while (gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] != null);
            gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] = animal;
            animal.PositionOnField.XPosition = randomPosition.XPosition;
            animal.PositionOnField.YPosition = randomPosition.YPosition;
            inputOutput.DrawGameField(gameField);
        }
    }
}
