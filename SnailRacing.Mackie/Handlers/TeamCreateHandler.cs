using MediatR;
using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Handlers
{
    internal class TeamCreateHandler : IRequestHandler<TeamCreateRequest, TeamCreateResponse>
    {
        private readonly ITeamRepository _repository;

        public TeamCreateHandler(ITeamRepository repository) => _repository = repository;

        public async Task<TeamCreateResponse> Handle(TeamCreateRequest request, CancellationToken cancellationToken)
        {
            _repository.Add(new Team
            {
                GuildId = request.GuildId,
                Name = request.Name,
                CreatedOn = request.When,
                CreatedBy = request.Username
            });
            await _repository.Commit();
            return new TeamCreateResponse();
        }
    }
}
