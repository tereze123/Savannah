using Application.GameEngine;
using Application.GameEngine.Factories;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameEngineFactory gameEngineFactory = new GameEngineFactory();
            SavannahEngine savannahEngine = gameEngineFactory.GetNewGameEngine();
            savannahEngine.Start();
        }
    }
}
