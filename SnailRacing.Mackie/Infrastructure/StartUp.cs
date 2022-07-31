using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnailRacing.Mackie.Discord;
using SnailRacing.Mackie.Models;

namespace SnailRacing.Mackie.Infrastructure
{
    internal static class StartUp
    {
        public static AppConfig AppConfig { get; } = new AppConfig();

        public static async Task Init()
        {
            var config = SetupConfig();
            config.Bind(AppConfig);
            var discord = CreateDiscordClient(AppConfig);
            var services = ServiceInstaller.ConfigureServices(AppConfig, discord);

            RegisterDiscordCommands(discord, services);

            await discord.ConnectAsync();
        }

        private static void RegisterDiscordCommands(DiscordClient discord, ServiceProvider services)
        {
            var slash = discord.UseSlashCommands( new SlashCommandsConfiguration
            {
                Services = services
            });

            //To register them for a single server, recommended for testing
            slash.RegisterCommands<TeamCommands>(935530784297738332);

            //To register them globally, once you're confident that they're ready to be used by everyone
            //slash.RegisterCommands<SlashCommands>();
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

        private static DiscordClient CreateDiscordClient(AppConfig config)
        {
            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = config?.Discord?.Token ?? throw new Exception("No Discord Token in config"),
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            });

            return discord;
        }
    }
}
