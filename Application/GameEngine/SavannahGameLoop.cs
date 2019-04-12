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
                    animal.AnimalsPositionOnField.ColumnPosition = newPosition.ColumnPosition;
                    animal.AnimalsPositionOnField.RowPosition = newPosition.RowPosition;
                    NextGenerationArray[newPosition.RowPosition, newPosition.ColumnPosition] = animal;
                }               
            }
            return NextGenerationArray;
        }

        public void UsersTurnToAddAnimals(SavannahGameState savannahGameState, string keyPressed)
        {
                if (keyPressed == "A")
                {
                    IAnimal antilope = new Antelope(randomiserFascade);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, antilope);
                    savannahGameState.AnimalCollection.Add(antilope);
                }
                else if (keyPressed == "L")
                {
                    IAnimal lion = new Lion(randomiserFascade);
                    savannahGameGameLogic.PlaceAnimalOnRandomAndFreePosition(savannahGameState, lion);
                    savannahGameState.AnimalCollection.Add(lion);
                }
        }
    }
}
