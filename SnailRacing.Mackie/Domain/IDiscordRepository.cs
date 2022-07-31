namespace SnailRacing.Mackie.Domain
{
    internal interface IDiscordRepository
    {
        Task AddRoleAsync(ulong guildId, string roleName);
        Task AddUserToRole(ulong guildId, string roleName, string userName);
        Task CreateTextChannel(ulong guildId, string channelName, string roleName);
        Task CreateVoiceChannel(ulong guildId, string channelName, string roleName);
    }
}
