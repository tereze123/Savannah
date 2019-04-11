namespace Savannah.Application.GameEngine
{
    public class SavannahGameLoop
    {
        private void LoopTheGame()
        {
            this.UsersTurnToAddAnimals();
            this.PlayGame();
            inputOutput.DrawGameField(gameField);
        }

        private void UsersTurnToAddAnimals()
        {
            string keyPressedByUser;
            do
            {
                keyPressedByUser = inputOutput.ReturnKeyPressed();
                if (keyPressedByUser == "A")
                {
                    IAnimal antilope = new Antelope();
                    this.AnimalCollection.Add(antilope);
                    this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, antilope);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    this.AnimalCollection.Add(lion);
                    this.PlaceNewAnimalAtRandomFreeSpaceWhenKeyPressed(gameField, lion);
                }
            } while (keyPressedByUser != "ESC");
        }
    }
}
