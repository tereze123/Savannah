using Savannah.Common.Factories;
using System;

namespace Savannah.Common.Facades
{
    public class RandomiserFascade : IRandomiserFascade
    {
        private readonly IRandomiserFactory randomiserFactory;

        public Random Randomiser { get; set; }

        public RandomiserFascade(IRandomiserFactory randomiserFactory)
        {
            this.randomiserFactory = randomiserFactory;
            Randomiser = randomiserFactory.GetNewRandomiser();
        }
        public int Next(int minValue, int maxValue)
        {            
            return Randomiser.Next(minValue, maxValue);
        }
    }
}
