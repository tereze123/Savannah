using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Common;
using System;

namespace Presentation.Implementation
{
    public class InputAndOutputForConsole : IInputOutput
    {
        private ConsoleKeyInfo consoleKeyInfo;

        private readonly int OFFSET_FROM_LEFT_SIDE;
        private readonly int OFFSET_FROM_TOP;

        private readonly IConfigurationFactory configurationFactory;

        public InputAndOutputForConsole(IConfigurationFactory configurationFactory)
        {
            this.configurationFactory = configurationFactory;
            OFFSET_FROM_LEFT_SIDE = configurationFactory.GetOffsetFromLeftSideFromConfigurationFile();
            OFFSET_FROM_TOP = configurationFactory.GetOffsetFromTopFromConfigurationFile();
        }

        public void DrawGameField(SavannahGameState gameField)
        {
            Console.CursorVisible = false;

            for (int rowNumber = 0; rowNumber < gameField.GameField.GetLength(0); rowNumber++)
            {
                this.DrawTopAndBottomBorder(gameField, rowNumber);

                for (int columnNumber = 0; columnNumber < gameField.GameField.GetLength(0); columnNumber++)
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

        private void OutputAnimalNameOrBlank(SavannahGameState gameField, int rowNumber, int columnNumber)
        {
            if (gameField.GameField[rowNumber, columnNumber] == null)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(gameField.GameField[rowNumber, columnNumber].Name);
            }
        }

        private void DrawSideBorders(SavannahGameState gameField, int rowNumber, int columnNumber)
        {
            if (columnNumber == 0)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1 + columnNumber, OFFSET_FROM_TOP + rowNumber);
                Console.Write("-");
            }
            if (columnNumber == gameField.GameField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE + (gameField.GameField.GetLength(0)), OFFSET_FROM_TOP + rowNumber);
                Console.Write("-");
            }
        }

        private void DrawTopAndBottomBorder(SavannahGameState gameField, int rowNumber)
        {
            if (rowNumber == 0)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1, OFFSET_FROM_TOP - 1);
                for (int a = 0; a < gameField.GameField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
            if (rowNumber == gameField.GameField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(OFFSET_FROM_LEFT_SIDE - 1, gameField.GameField.GetLength(0) + OFFSET_FROM_TOP);
                for (int a = 0; a < gameField.GameField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
        }
    }
}
