using System;
using System.Collections.Generic;
using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Entities.SavannahGame.Implementation;

namespace Savannah.Application.GameEngine
{
    public class SavannahGameLoop
    {
        private readonly IInputOutput inputOutput;
        private readonly SavannahGameLogic savannahGameGameLogic;
        private readonly SavannahGameState savannahGameState;

        public SavannahGameLoop(IInputOutput inputOutput, 
            SavannahGameState savannahGameState, 
            SavannahGameLogic savannahGameGameLogic
            )
        {
            this.inputOutput = inputOutput;
            this.savannahGameGameLogic = savannahGameGameLogic;
            this.savannahGameState = savannahGameState;
        }

        public List<IAnimal> AnimalCollection { get; private set; }

        public void LoopTheGame(IInputOutput inputOutput)
        {
            this.UsersTurnToAddAnimals();
            //this.PlayGame();
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
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, antilope);
                    inputOutput.DrawGameField(savannahGameState);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    this.AnimalCollection.Add(lion);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, lion);
                }
            } while (keyPressedByUser != "ESC");
        }
    }
}
