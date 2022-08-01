using MediatR;

namespace SnailRacing.Mackie.Handlers.GuildHandlers
{
    internal class GuildSetConfigRequest : IRequest
    {
        public ulong GuildId { get; set; }
    }
}
