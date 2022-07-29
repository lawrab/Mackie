using DSharpPlus;
using Microsoft.Extensions.Configuration;
using SnailRacing.Mackie.Models;
using DSharpPlus.SlashCommands;
using SnailRacing.Mackie.Discord;

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
            RegisterDiscordCommands(discord);

            await discord.ConnectAsync();
        }

        private static void RegisterDiscordCommands(DiscordClient discord)
        {
            var slash = discord.UseSlashCommands();

            //To register them for a single server, recommended for testing
            slash.RegisterCommands<SlashCommands>(935530784297738332);

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
            var discord = new DiscordClient( new DiscordConfiguration
            {
                Token = config?.Discord?.Token ?? throw new Exception("No Discord Token in config"),
                TokenType = TokenType.Bot
            });

            return discord;
        }
    }
}
