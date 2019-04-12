using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Common;
using Savannah.Common.Facades;
using Savannah.Entities.Factories;

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
            inputOutput.DrawGameField(GameState);
            for (int i = 0; i < 1000; i++)
            {
                GameState.GameField =  loopGame.LoopTheGame(GameState);
            }
        }
    }
}
