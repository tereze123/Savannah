using Application.AppStart.Dependencies;
using Application.GameEngine;
using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Implementation;
using Presentation.Interfaces;
using System;

namespace Application
{
   public class Program
    {


        //public SavannahEngine FactoryTest()
        //{
        //    var serviceProvider = tGetServiceProvider();
        //    SavannahEngine savannahGame = serviceProvider.GetService<SavannahEngine>();
        //    return savannahGame;
        //}

        static void Main(string[] args)
        {
            DependencyInjectionContainer dependencyInjectionContainer = new DependencyInjectionContainer();
            ServiceProvider serviceProvider = dependencyInjectionContainer.GetServiceProvider();
            SavannahEngine savannahEngine = serviceProvider.GetService<SavannahEngine>();
            savannahEngine.Start();
            Console.ReadLine();
        }
    }
}
