using AdventOfCodeClient.interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AdventOfCodeClient
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationSection adventOfCodeConfiguration;

        public string Year => this.GetParameter("year");
        public string Session => this.GetParameter("session");
        public bool UseProblemSender => bool.Parse(this.GetParameter("UseProblemSender"));

        public ConfigurationService(string configFilePath)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile(configFilePath, optional: false, reloadOnChange: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
            this.adventOfCodeConfiguration = configBuilder.Build().GetSection("AdventOfCode");
        }

        public ConfigurationService(string configFilePath, Assembly executingAssembly)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile(configFilePath, optional: false, reloadOnChange: true)
                .AddUserSecrets(executingAssembly, true);
            this.adventOfCodeConfiguration = configBuilder.Build().GetSection("AdventOfCode");
        }

        public string GetParameter(string parameterName)
        {
            var parameterSection = this.adventOfCodeConfiguration.GetSection(parameterName);
            if (!parameterSection.Exists())
            {
                throw new ArgumentException();
            }
            return parameterSection.Value;
        }
    }
}
