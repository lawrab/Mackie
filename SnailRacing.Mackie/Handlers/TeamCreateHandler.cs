using MediatR;

namespace SnailRacing.Mackie.Handlers
{
    internal class TeamCreateHandler : IRequestHandler<TeamCreateRequest, TeamCreateResponse>
    {
        public Task<TeamCreateResponse> Handle(TeamCreateRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TeamCreateResponse());
        }
    }
}
