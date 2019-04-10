using Entities.GameField;
using Presentation.Interfaces;
using System;
namespace Presentation.Implementation
{
    public class InputAndOutputForConsole : IInputOutput
    {
        private ConsoleKeyInfo consoleKeyInfo;

        public InputAndOutputForConsole()
        {
            this.consoleKeyInfo = new ConsoleKeyInfo();
        }

        public void DrawGameField(ISavannahGameField gameField)
        {
            Console.CursorVisible = false;

            for (int x = 0; x < gameField.SavannahField.GetLength(0); x++)
            {
                this.DrawTopAndBottomBorder(gameField, x);

                for (int y = 0; y < gameField.SavannahField.GetLength(0); y++)
                {
                    this.DrawSideBorders(gameField, x, y);
                    Console.SetCursorPosition(10 + (y), 5 + x);
                    this.OutputAnimalNameOrBlank(gameField, x, y);
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
            }while(consoleKeyInfo.Key != ConsoleKey.Escape);
            return "ESC";
        }

        private void OutputAnimalNameOrBlank(ISavannahGameField gameField,int x, int y)
        {
            if (gameField.SavannahField[x, y] == null)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(gameField.SavannahField[x, y].Name);
            }
        }

        private void DrawSideBorders(ISavannahGameField gameField, int x, int y)
        {
            if (y == 0)
            {
                Console.SetCursorPosition(9 + (y), 5 + x);
                Console.Write("-");
            }
            if (y == gameField.SavannahField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(10 + (gameField.SavannahField.GetLength(0)), 5 + x);
                Console.Write("-");
            }
        }

        private void DrawTopAndBottomBorder(ISavannahGameField gameField, int x)
        {
            if (x == 0)
            {
                Console.SetCursorPosition(9, 4);
                for (int a = 0; a < gameField.SavannahField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
            if (x == gameField.SavannahField.GetLength(0) - 1)
            {
                Console.SetCursorPosition(9, gameField.SavannahField.GetLength(0) + 5);
                for (int a = 0; a < gameField.SavannahField.GetLength(0) + 2; a++)
                {
                    Console.Write("-");
                }
            }
        }
    }
}
