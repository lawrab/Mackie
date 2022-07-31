using MediatR;
using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Handlers
{
    internal class TeamCreateHandler : IRequestHandler<TeamCreateRequest, TeamCreateResponse>
    {
        private readonly ITeamRepository _repository;
        private readonly IDiscordRepository _discord;

        public TeamCreateHandler(ITeamRepository repository, IDiscordRepository discord)
        {
            _repository = repository;
            _discord = discord;
        }

        public async Task<TeamCreateResponse> Handle(TeamCreateRequest request, CancellationToken cancellationToken)
        {
            await _discord.AddRoleAsync(request.GuildId, request.Name);
            await _discord.CreateTextChannel(request.GuildId, request.Name, string.Empty);

            _repository.Add(new Team
            {
                GuildId = request.GuildId.ToString(),
                Name = request.Name,
                CreatedOn = request.When,
                CreatedBy = request.Username
            });
            await _repository.Commit();
            return new TeamCreateResponse();
        }
    }
}
