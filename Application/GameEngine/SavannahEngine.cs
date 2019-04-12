using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Common;
using Savannah.Common.Facades;
using Savannah.Entities.Factories;
using System.Threading;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        
        private readonly ISavannahGameStateFactory savannahGameStateFactory ;
        private readonly IConfigurationFactory configurationFactory;
        private readonly IRandomiserFascade randomiserFascade;
        private readonly IInputOutput inputOutput;
        private readonly ISavannahGameLoop loopGame;


        public SavannahGameState GameState { get; set; }

        public SavannahEngine( 
            IInputOutput inputOutput, 
            ISavannahGameLoop loopGame, 
            ISavannahGameStateFactory savannahGameStateFactory,
            IConfigurationFactory configurationFactory,
            IRandomiserFascade randomiserFascade
            )
        {
            this.savannahGameStateFactory = savannahGameStateFactory;
            this.configurationFactory = configurationFactory;
            this.randomiserFascade = randomiserFascade;
            this.inputOutput = inputOutput;
            this.loopGame = loopGame;
            GameState = savannahGameStateFactory.GetNewSavannahGameState(configurationFactory);
        }

        public void Start()
        {
            string userInput = "";
            inputOutput.DrawGameField(GameState);
            do
            {
                if (inputOutput.IsKeYPressed())
                {
                    userInput = inputOutput.ReturnKeyPressed();

                    if (userInput == "L" || userInput == "A")
                    {
                        loopGame.UsersTurnToAddAnimals(GameState, userInput);
                        inputOutput.DrawGameField(GameState);
                    }
                }
                GameState.GameField = loopGame.LoopTheGame(GameState);
                inputOutput.DrawGameField(GameState);
                Thread.Sleep(10);
            } while (userInput != "ESC");
        }
    }
}
