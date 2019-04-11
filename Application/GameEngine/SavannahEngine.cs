using Entities.Animals;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Interfaces;
using Savannah.Application.GameEngine;
using System;
using System.Collections.Generic;

namespace Application.GameEngine
{
    public class SavannahEngine
    {
        public List<IAnimal> AnimalCollection { get; set; }
        private readonly SavannahGameState gameField;
        private readonly IInputOutput inputOutput;
        private readonly SavannahGameLoop loopGame;
        private readonly Random random;
        private PositionOnField randomPosition;

        public SavannahEngine(SavannahGameState gameField, IInputOutput inputOutput, SavannahGameLoop loopGame)
        {
            this.AnimalCollection = new List<IAnimal>();
            this.gameField = gameField;
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
                loopGame.LoopTheGame(inputOutput, gameField);
            }
        }

 
    }
}
