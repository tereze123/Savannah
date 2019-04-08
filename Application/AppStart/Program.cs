using Application.GameEngine;
using Entities.Animals.Implementation;
using Entities.GameField;
using Presentation.Implementation;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            SavannahEngine savannahEngine = new SavannahEngine();
            savannahEngine.Start();
        }
    }
}
