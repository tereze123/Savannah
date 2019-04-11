using System;
using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;

namespace Savannah.Application.GameEngine
{
    public class SavannahGameLoop
    {
        private readonly IInputOutput inputOutput;
        private readonly SavannahGameState savannahGameState;

        public SavannahGameLoop(IInputOutput inputOutput, SavannahGameState savannahGameState)
        {
            this.inputOutput = inputOutput;
            this.savannahGameState = savannahGameState;
        }
        public void LoopTheGame(IInputOutput inputOutput, SavannahGameState savannahGameState)
        {
            this.UsersTurnToAddAnimals();
            this.PlayGame();
            inputOutput.DrawGameField(savannahGameState);
        }

        private void PlayGame()
        {
            throw new NotImplementedException();
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
                    this.PlaceAnimalOnRandomAndFreePosition(gameField, antilope);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    this.AnimalCollection.Add(lion);
                    this.PlaceAnimalOnRandomAndFreePosition(gameField, lion);
                }
            } while (keyPressedByUser != "ESC");
        }
    }
}
