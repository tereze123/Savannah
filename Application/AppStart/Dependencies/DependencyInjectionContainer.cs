using Entities.GameField;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Implementation;
using Presentation.Interfaces;

namespace Application.AppStart.Dependencies
{
    public class DependencyInjectionContainer
    {
        public ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                    .AddTransient<IInputOutput, InputAndOutputForConsole>()
                    .AddTransient<SavannahGameState, SavannahGame>()
                    .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
