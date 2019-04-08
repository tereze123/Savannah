using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Implementation;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        public void Start()
        {
            SavannahGameField gameField = new SavannahGameField();
            DrawGameScreen(gameField);
        }

        private void DrawGameScreen(SavannahGameField gameField)
        {
            DrawGameFieldToConsole gameFieldDrawer = new DrawGameFieldToConsole();
            gameFieldDrawer.DrawGameField(gameField);
        }

        private void PlaceAnimalAtRandomFreeSpaceWhenKeyPressed(SavannahGameField gameField, string animalType)
        {


            gameField.SavannahField[4, 4] = new Lion();
        }

        private bool IsAnimalKeyPressed()
        {

        }
    }
}
