using Entities.GameField;
using Presentation.Interfaces;
using System;
namespace Presentation.Implementation
{
    public class DrawGameFieldToConsole : IFieldDraw
    {
        public void DrawGameField(SavannahGameField gameField)
        {
            for (int x = 0; x < gameField.SavannahField.GetLength(0); x++)
            {
                for (int y = 0; y < gameField.SavannahField.GetLength(0); y++)
                {
                    Console.SetCursorPosition(10 + (y * 3), 5 + x);
                    OutputAnimalNameOrBlank(gameField, x, y);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private void OutputAnimalNameOrBlank(SavannahGameField gameField,int x, int y)
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
