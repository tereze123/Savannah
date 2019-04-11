using System;

namespace Savannah.Common.Factories
{
    public class RandomiserFactory 
    {
        public Random GetNewRandomiser()
        {
            return new Random();
        }
    }
}
