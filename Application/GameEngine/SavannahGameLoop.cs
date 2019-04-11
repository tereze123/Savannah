using System;
using System.Collections.Generic;
using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Entities.SavannahGame.Implementation;

namespace Savannah.Application.GameEngine
{
    public class SavannahGameLoop : ISavannahGameLoop
    {
        private readonly IInputOutput inputOutput;
        private readonly ISavannahGameLogic savannahGameGameLogic;
        private SavannahGameState savannahGameState;

        public SavannahGameLoop(IInputOutput inputOutput, 
            SavannahGameState savannahGameState,
            ISavannahGameLogic savannahGameGameLogic
            )
        {
            this.inputOutput = inputOutput;
            this.savannahGameGameLogic = savannahGameGameLogic;
            this.savannahGameState = savannahGameState;
            AnimalCollection = new List<IAnimal>();
            InitialArray = savannahGameState.GameField;
            NextGenerationArray = new IAnimal[InitialArray.GetLength(0), InitialArray.GetLength(0)];
        }

        public List<IAnimal> AnimalCollection { get; private set; }

        public IAnimal[,] InitialArray;

        public IAnimal[,] NextGenerationArray;

        public void LoopTheGame()
        {
            this.UsersTurnToAddAnimals();
            savannahGameState.GameField =  this.GetNextGeneration();
            inputOutput.DrawGameField(savannahGameState);
        }

        private IAnimal[,] GetNextGeneration()
        {
            foreach (var animal in AnimalCollection)
            {
                var enemyPosition = animal.GetEnemysPositionOnField(InitialArray);
                if (enemyPosition.IsInViewRange == true)
                {
                   var newPosition = animal.ActionWhenSeesEnenmy(ref NextGenerationArray, enemyPosition);
                    NextGenerationArray[newPosition.RowPosition, newPosition.ColumnPosition] = animal;
                }
                else
                {
                    var newPosition = animal.PeaceStateMovementNextPosition(ref InitialArray,ref NextGenerationArray);
                    NextGenerationArray[newPosition.RowPosition, newPosition.ColumnPosition] = animal;
                }               
            }
            return NextGenerationArray;
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
                    this.AnimalCollection.Add(antilope);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    this.AnimalCollection.Add(lion);
                    inputOutput.DrawGameField(savannahGameState);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, lion);
                }
            } while (keyPressedByUser != "ESC");
        }
    }
}
