namespace SnailRacing.Mackie.Domain
{
    internal class Configuration
    {
        public int Id { get; set; }
        public string GuildId { get; set; } = string.Empty;
        public string TeamsTextParentChannelId { get; set; } = string.Empty;
        public string TeamsTextParentChannelName { get; set; } = string.Empty;
        public string TeamsVoiceParentChannelId { get; set; } = string.Empty;
        public string TeamsVoiceParentChannelName { get; set; } = string.Empty;
    }
}
