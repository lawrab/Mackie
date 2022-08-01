namespace SnailRacing.Mackie.Domain
{
    internal class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TeamMember> TeamMembers { get; set; } = new();
        public string GuildId { get; internal set; } = string.Empty;
        public string CreatedBy { get; internal set; } = string.Empty;
        public DateTime CreatedOn { get; internal set; }
    }
}
