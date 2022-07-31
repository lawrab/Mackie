using MediatR;

namespace SnailRacing.Mackie.Handlers
{
    internal class TeamCreateRequest : IRequest<TeamCreateResponse>
    {
        public string GuildId { get; internal set; } = string.Empty;
        public string Name { get; internal set; } = string.Empty;
        public string Username { get; internal set; } = string.Empty;
        public DateTime When { get; internal set; }
    }
}
