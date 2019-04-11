using System;

namespace Savannah.Common.Factories
{
    public interface IRandomiserFactory
    {
        Random GetNewRandomiser();
    }
}