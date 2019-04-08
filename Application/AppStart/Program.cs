using Application.GameEngine;
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            SavannahEngine savannahEngine = new SavannahEngine();
            savannahEngine.Start();
            Console.ReadLine();
        }
    }
}
