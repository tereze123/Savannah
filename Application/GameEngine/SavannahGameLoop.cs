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
            NextGenerationArray = savannahGameState.GameField;
            return  this.GetNextGeneration(savannahGameState);
        }

        private IAnimal[,] GetNextGeneration(SavannahGameState savannahGameState)
        {

            foreach (var animal in savannahGameState.AnimalCollection)
            {
                if (animal != null)
                {
                    var enemyPosition = animal.GetEnemysPositionOnField(ref NextGenerationArray);
                    if (enemyPosition.IsInViewRange == true)
                    {
                        NextGenerationArray[animal.AnimalsPositionOnField.RowPosition, animal.AnimalsPositionOnField.ColumnPosition] = null;
                        var newPosition = animal.ActionWhenSeesEnenmy(ref NextGenerationArray, enemyPosition);
                        animal.AnimalsPositionOnField.ColumnPosition = newPosition.ColumnPosition;
                        animal.AnimalsPositionOnField.RowPosition = newPosition.RowPosition;
                        NextGenerationArray[newPosition.RowPosition, newPosition.ColumnPosition] = animal;
                    }
                    else
                    {
                        NextGenerationArray[animal.AnimalsPositionOnField.RowPosition, animal.AnimalsPositionOnField.ColumnPosition] = null;
                        var newPosition = animal.PeaceStateMovementNextPosition(ref NextGenerationArray, ref NextGenerationArray);
                        animal.AnimalsPositionOnField.ColumnPosition = newPosition.ColumnPosition;
                        animal.AnimalsPositionOnField.RowPosition = newPosition.RowPosition;
                        NextGenerationArray[newPosition.RowPosition, newPosition.ColumnPosition] = animal;
                    }
                }
                else
                { }
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
