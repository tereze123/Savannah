using Entities.GameField;
using Presentation.Interfaces;
using System;
namespace Presentation.Implementation
{
    public class DrawGameFieldToConsole : IFieldDraw
    {
        public void DrawGameField(SavannahGameField gameField)
        {
            for (int i = 0; i < gameField.SavannahField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.SavannahField.GetLength(0); j++)
                {
                    Console.SetCursorPosition(10 + (j * 2), 5 + i);
                    Console.Write("__");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
