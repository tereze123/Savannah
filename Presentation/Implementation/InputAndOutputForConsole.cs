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
                if(x == 0)
                {
                    Console.SetCursorPosition(9, 4);
                    for (int a = 0; a < gameField.SavannahField.GetLength(0) * 3 + 1; a++)
                    {
                        Console.Write("-");
                    }
                }                
                for (int y = 0; y < gameField.SavannahField.GetLength(0); y++)
                {
                    if (y == 0)
                    {
                        Console.SetCursorPosition(9 + (y * 3), 4 + x);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(10 + (y * 3), 5 + x);
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
                Console.Write("   ");
            }
            else
            {
                Console.Write($" " + gameField.SavannahField[x, y].Name + " ");
            }
        }
    }
}
