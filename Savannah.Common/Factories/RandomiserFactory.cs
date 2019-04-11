using System;

namespace Savannah.Common.Factories
{
    public class RandomiserFactory: IRandomiserFactory
    {
        public Random GetNewRandomiser()
        {
            return new Random();
        }
    }
}
