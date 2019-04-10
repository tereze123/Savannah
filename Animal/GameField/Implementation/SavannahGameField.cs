using Entities.Animals;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Entities.GameField
{
    public class SavannahGameField : ISavannahGameField
    {
        public IAnimal[,] SavannahField { get; set; }

        public SavannahGameField()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            int FIELD_SIZE = int.Parse(configuration["FieldSize"]);

            this.SavannahField = new IAnimal[FIELD_SIZE, FIELD_SIZE];
        }       
    }
}
