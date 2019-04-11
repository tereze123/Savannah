using Microsoft.Extensions.Configuration;
using System.IO;

namespace Savannah.Common
{
    public class SavannahConfiguration : IConfigurationFactory
    {
        private IConfigurationBuilder _builder;

        private IConfigurationRoot _configuration;
        
        public SavannahConfiguration()
        {
            _builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            _configuration = _builder.Build();
        }

        public int GetFieldSizeFromConfigurationFile()
        {
            return int.Parse(_configuration["FieldSize"]);            
        }

        public int GetOffsetFromTopFromConfigurationFile()
        {
            return int.Parse(_configuration["OffsetFromTop"]);
        }

        public int GetOffsetFromLeftSideFromConfigurationFile()
        {
            return int.Parse(_configuration["OffsetFromLeftSide"]);
        }
    }
}
