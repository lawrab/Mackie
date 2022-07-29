using Microsoft.Extensions.Configuration;
using SnailRacing.Mackie.Models;

namespace SnailRacing.Mackie.Infrastructure
{
    internal static class StartUp
    {
        public static AppConfig AppConfig { get; } = new AppConfig();

        public static void Init()
        {
            var config = SetupConfig();
            InitConfig(config);
        }

        private static void InitConfig(IConfigurationRoot config)
        {
            config.Bind(AppConfig);
        }
        private static IConfigurationRoot SetupConfig()
        {
            var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "DEV";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            if (env?.ToUpper() == "DEV") builder.AddUserSecrets<Program>();

            return builder.Build();
        }
    }
}
