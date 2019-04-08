using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Implementation;
using System;
using System.Threading;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        public void Start()
        {
            SavannahGameField gameField = new SavannahGameField();
            this.DrawGameScreen(gameField);
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.A) { this.PlaceNewAntelopeAtRandomFreeSpaceWhenKeyPressed(gameField); }
                else if(cki.Key == ConsoleKey.L) { this.PlaceNewLionAtRandomFreeSpaceWhenKeyPressed(gameField); }
            } while (cki.Key != ConsoleKey.Escape);            
        }

        private void DrawGameScreen(SavannahGameField gameField)
        {
            DrawGameFieldToConsole gameFieldDrawer = new DrawGameFieldToConsole();
            gameFieldDrawer.DrawGameField(gameField);
        }

        private PositionOnField GetRandomPositionOnField()
        {
            var random = new Random();
            PositionOnField positionOnField = new PositionOnField();
            positionOnField.XPosition = random.Next(0, 20);
            positionOnField.YPosition = random.Next(0, 20);
            return positionOnField;
        }

        private void PlaceNewLionAtRandomFreeSpaceWhenKeyPressed(SavannahGameField gameField)
        {
            PositionOnField randomPosition = new PositionOnField();
            do
            {
                randomPosition = GetRandomPositionOnField();
            } while (gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] != null);

            gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] = new Lion();
            this.DrawGameScreen(gameField);
        }

        private void PlaceNewAntelopeAtRandomFreeSpaceWhenKeyPressed(SavannahGameField gameField)
        {
            PositionOnField randomPosition = new PositionOnField();
            do
            {
                randomPosition = GetRandomPositionOnField();
            } while (gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] != null);
            gameField.SavannahField[randomPosition.XPosition, randomPosition.YPosition] = new Antelope();
            this.DrawGameScreen(gameField);
        }


    }
}
