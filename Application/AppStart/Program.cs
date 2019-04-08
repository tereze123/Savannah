using Entities.GameField;
using Presentation.Implementation;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            DrawGameFieldToConsole drawGameField = new DrawGameFieldToConsole();
            drawGameField.DrawGameField(new SavannahGameField());
        }
    }
}
