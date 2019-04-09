using Application.GameEngine;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Implementation;
using Presentation.Interfaces;
using System;

namespace Application
{
   public class Program
    {
        public void Configure()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddTransient<IInputOutput, InputAndOutputForConsole>();
        }

        static void Main(string[] args)
        {
            SavannahEngine savannahEngine = new SavannahEngine();
            savannahEngine.Start();
            Console.ReadLine();
        }
    }
}
