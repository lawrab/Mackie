using MediatR;

namespace SnailRacing.Mackie.Handlers
{
    internal class TeamCreateRequest : IRequest<TeamCreateResponse>
    {
        public string Name { get; internal set; } = string.Empty;
    }
}
