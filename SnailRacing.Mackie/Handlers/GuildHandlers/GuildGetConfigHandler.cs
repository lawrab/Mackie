using MediatR;
using SnailRacing.Mackie.Domain;

namespace SnailRacing.Mackie.Handlers.GuildHandlers
{
    internal class GuildGetConfigHandler : IRequestHandler<GuildGetConfigRequest, GuildGetConfigResponse>
    {
        private readonly IRepository<Configuration> _repository;
        private readonly IDiscordRepository _discord;

        public GuildGetConfigHandler(IRepository<Configuration> repository, IDiscordRepository discord)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _discord = discord ?? throw new ArgumentNullException(nameof(discord));
        }

        public Task<GuildGetConfigResponse> Handle(GuildGetConfigRequest request, CancellationToken cancellationToken)
        {
            var config = _repository.FindAsync(c => c.GuildId == request.GuildId.ToString());

            return Task.FromResult(new GuildGetConfigResponse());
        }
    }
}
