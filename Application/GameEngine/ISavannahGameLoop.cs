using System.Collections.Generic;
using Entities.Animals;

namespace Savannah.Application.GameEngine
{
    public interface ISavannahGameLoop
    {
        List<IAnimal> AnimalCollection { get; }

        void LoopTheGame();
    }
}