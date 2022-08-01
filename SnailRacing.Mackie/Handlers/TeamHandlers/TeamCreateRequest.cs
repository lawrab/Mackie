using MediatR;

namespace SnailRacing.Mackie.Handlers.TeamHandlers
{
    internal class TeamCreateRequest : IRequest<TeamCreateResponse>
    {
        public ulong GuildId { get; internal set; }
        public string Name { get; internal set; } = string.Empty;
        public string Username { get; internal set; } = string.Empty;
        public DateTime When { get; internal set; }
    }
}
