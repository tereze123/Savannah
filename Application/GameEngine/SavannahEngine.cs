using Entities.Animals;
using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using Savannah.Entities.Factories;
using System;
using System.Collections.Generic;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        public List<IAnimal> AnimalCollection { get; set; }
        private readonly ISavannahGameStateFactory savannahGameStateFactory ;
        private readonly IInputOutput inputOutput;
        private readonly ISavannahGameLoop loopGame;
        private readonly Random random;
        private PositionOnField randomPosition;

        public SavannahEngine( IInputOutput inputOutput, ISavannahGameLoop loopGame, ISavannahGameStateFactory savannahGameStateFactory)
        {
            this.AnimalCollection = new List<IAnimal>();
            this.savannahGameStateFactory = savannahGameStateFactory;
            this.inputOutput = inputOutput;
            this.loopGame = loopGame;
            this.random = new Random();
            this.randomPosition = new PositionOnField();
        }

        public void Start()
        {
            inputOutput.DrawGameField(gameField);
            for (int i = 0; i < 1000; i++)
            {
                loopGame.LoopTheGame();
            }
        }
    }
}
