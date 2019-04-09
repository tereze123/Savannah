using Entities.GameField;
using Presentation.Interfaces;
using System;
namespace Presentation.Implementation
{
    public class InputAndOutputForConsole : IInputOutput
    {
        private ConsoleKeyInfo consoleKeyInfo;

        public InputAndOutputForConsole(ConsoleKeyInfo consoleKeyInfo)
        {
            this.consoleKeyInfo = consoleKeyInfo;
        }
        public void DrawGameField(ISavannahGameField gameField)
        {
            for (int x = 0; x < gameField.SavannahField.GetLength(0); x++)
            {
                for (int y = 0; y < gameField.SavannahField.GetLength(0); y++)
                {
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
                Console.Write("|__");
            }
            else
            {
                Console.Write($"|" + gameField.SavannahField[x, y].Name + "_");
            }
        }
    }
}
