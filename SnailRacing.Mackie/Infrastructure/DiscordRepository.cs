using DSharpPlus;
using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Infrastructure
{
    internal class DiscordRepository : IDiscordRepository
    {
        private readonly DiscordClient _discord;

        public DiscordRepository(DiscordClient discord) => _discord = discord;

        public async Task AddRoleAsync(ulong guildId, string roleName)
        {
            var guild = _discord.Guilds[guildId];
            await guild.CreateRoleAsync(roleName);
        }

        public Task AddUserToRole(ulong guildId, string roleName, string userName)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTextChannel(ulong guildId, string channelName, string roleName)
        {
            var guild = _discord.Guilds[guildId];
            var teamChannelGroup = guild.Channels.Where(c => c.Value.Name == "Teams").FirstOrDefault().Value;
            var channel = await guild.CreateTextChannelAsync(channelName, teamChannelGroup);
        }

        public Task CreateVoiceChannel(ulong guildId, string channelName, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
