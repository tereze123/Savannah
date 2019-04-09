using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Implementation;
using System;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        private readonly SavannahGameField gameField;
        private readonly DrawGameFieldToConsole gameFieldDrawer;
        private readonly Random random;
        private ConsoleKeyInfo consoleKeyInfo;
        private PositionOnField randomPosition;

        private PositionOnField positionOnField { get; }

        public SavannahEngine(
            SavannahGameField gameField, 
            ConsoleKeyInfo consoleKeyInfo, 
            DrawGameFieldToConsole gameFieldDrawer,
            Random random,
            PositionOnField positionOnField,
            PositionOnField randomPosition)
        {
            this.gameField = gameField;
            this.consoleKeyInfo = consoleKeyInfo;
            this.gameFieldDrawer = gameFieldDrawer;
            this.random = random;
            this.positionOnField = positionOnField;
            this.randomPosition = randomPosition;
        }
        public void Start()
        {
            this.DrawGameScreen(gameField);
            do
            {
                consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.A) { this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, new Antelope()); }
                else if(consoleKeyInfo.Key == ConsoleKey.L) { this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, new Lion()); }
            } while (consoleKeyInfo.Key != ConsoleKey.Escape);            
        }

        private void DrawGameScreen(SavannahGameField gameField)
        {
            gameFieldDrawer.DrawGameField(gameField);
        }

        private PositionOnField GetRandomPositionOnField()
        {
            positionOnField.XPosition = random.Next(0, 20);
            positionOnField.YPosition = random.Next(0, 20);
            return positionOnField;
        }

        private void PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(SavannahGameField gameField, IAnimal animal)
        {
            do
            {
                randomPosition = GetRandomPositionOnField();
            } while (gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] != null);

            gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] = animal;
            this.DrawGameScreen(gameField);
        }
    }
}
