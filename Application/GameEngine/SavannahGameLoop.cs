using System;
using System.Collections.Generic;
using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Common.Facades;
using Savannah.Entities.SavannahGame.Implementation;

namespace Savannah.Application.GameEngine
{
    public class SavannahGameLoop : ISavannahGameLoop
    {
        public IAnimal[,] InitialArray;

        public IAnimal[,] NextGenerationArray;

        private readonly IInputOutput inputOutput;
        private readonly ISavannahGameLogic savannahGameGameLogic;
        private readonly IRandomiserFascade randomiserFascade;

        public SavannahGameLoop(IInputOutput inputOutput, 
            ISavannahGameLogic savannahGameGameLogic,
            IRandomiserFascade randomiserFascade
            )
        {
            this.inputOutput = inputOutput;
            this.savannahGameGameLogic = savannahGameGameLogic;
            this.randomiserFascade = randomiserFascade;

        }

        public IAnimal[,] LoopTheGame(SavannahGameState savannahGameState)
        {
            InitialArray = savannahGameState.GameField;
            NextGenerationArray = new IAnimal[InitialArray.GetLength(0), InitialArray.GetLength(0)];
            return  this.GetNextGeneration(savannahGameState);
        }

        private IAnimal[,] GetNextGeneration(SavannahGameState savannahGameState)
        {
            foreach (var animal in savannahGameState.AnimalCollection)
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

        private void UsersTurnToAddAnimals(SavannahGameState savannahGameState)
        {
            string keyPressedByUser;
            do
            {
                keyPressedByUser = inputOutput.ReturnKeyPressed();
                if (keyPressedByUser == "A")
                {
                    IAnimal antilope = new Antelope(randomiserFascade);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, antilope);
                    inputOutput.DrawGameField(savannahGameState);
                    savannahGameState.AnimalCollection.Add(antilope);
                }
                else if (keyPressedByUser == "L")
                {
                    IAnimal lion = new Lion();
                    savannahGameState.AnimalCollection.Add(lion);
                    inputOutput.DrawGameField(savannahGameState);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, lion);
                }
            } while (keyPressedByUser != "ESC");
        }
    }
}
