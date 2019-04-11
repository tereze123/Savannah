using Entities.GameField;
using Microsoft.Extensions.Configuration;
using Presentation.Interfaces;
using System;
using System.IO;

namespace Presentation.Implementation
{
    public class InputAndOutputForConsole : IInputOutput
    {
        private ConsoleKeyInfo consoleKeyInfo;

        private readonly int OFFSET_FROM_LEFT_SIDE;
        private readonly int OFFSET_FROM_TOP;

        public InputAndOutputForConsole()
        {
            this.consoleKeyInfo = new ConsoleKeyInfo();
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            this.OFFSET_FROM_LEFT_SIDE = int.Parse(configuration["OffsetFromLeftSide"]);
            this.OFFSET_FROM_TOP = int.Parse(configuration["OffsetFromTop"]);
        }

        public void DrawGameField(ISavannahGame gameField)
        {
            Console.CursorVisible = false;

            for (int rowNumber = 0; rowNumber < gameField.SavannahField.GetLength(0); rowNumber++)
            {
                this.DrawTopAndBottomBorder(gameField, rowNumber);

                for (int columnNumber = 0; columnNumber < gameField.SavannahField.GetLength(0); columnNumber++)
                {
                    this.DrawSideBorders(gameField, rowNumber, columnNumber);
                    Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE + columnNumber, OFFSET_FROM_TOP + rowNumber);
                    this.OutputAnimalNameOrBlank(gameField, rowNumber, columnNumber);
                }
                Console.WriteLine();
            }
        }

        public string ReturnKeyPressed()
        {
            do
            {
                consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.A) { return "A"; }
                else if (consoleKeyInfo.Key == ConsoleKey.L) { return "L"; }
            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
            return "ESC";
        }

        private void OutputAnimalNameOrBlank(ISavannahGame gameField, int rowNumber, int columnNumber)
        {
            if (gameField.SavannahField[rowNumber, columnNumber] == null)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(gameField.SavannahField[rowNumber, columnNumber].Name);
            }
        }

        private void DrawSideBorders(ISavannahGame gameField, int rowNumber, int columnNumber)
        {
            if (columnNumber == 0)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1 + columnNumber, OFFSET_FROM_TOP + rowNumber);
                Console.Write("-");
            }
            if (columnNumber == gameField.SavannahField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE + (gameField.SavannahField.GetLength(0)), OFFSET_FROM_TOP + rowNumber);
                Console.Write("-");
            }
        }

        private void DrawTopAndBottomBorder(ISavannahGame gameField, int rowNumber)
        {
            if (rowNumber == 0)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1, OFFSET_FROM_TOP - 1);
                for (int a = 0; a < gameField.SavannahField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
            if (rowNumber == gameField.SavannahField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1, gameField.SavannahField.GetLength(0) + OFFSET_FROM_TOP);
                for (int a = 0; a < gameField.SavannahField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
        }
    }
}
