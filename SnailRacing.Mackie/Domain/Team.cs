namespace SnailRacing.Mackie.Domain
{
    internal class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<TeamMember> TeamMembers { get; set; } = new();
    }
}
