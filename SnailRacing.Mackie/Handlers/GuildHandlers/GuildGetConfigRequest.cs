using MediatR;

namespace SnailRacing.Mackie.Handlers.GuildHandlers
{
    internal class GuildGetConfigRequest : IRequest<GuildGetConfigResponse>
    {
        public ulong GuildId { get; set; }
    }
}
