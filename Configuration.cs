using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace DevLifeBot
{
    class Configuration
    {
        public IConfigurationRoot Config { get; }

        public Configuration(string[] args)
        {
            var builder = new ConfigurationBuilder()     
                .SetBasePath(AppContext.BaseDirectory)   
                .AddYamlFile("config.yml");              
            Config = builder.Build();                    
        }

        public string GetConfig(string args)
        {
            Config.Reload();
            string result = Config[args];
            return result;
        }
    }
}
