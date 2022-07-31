using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MediatR;
using SnailRacing.Mackie.Domain;
using SnailRacing.Mackie.Handlers;

namespace SnailRacing.Mackie.Discord
{
    [SlashCommandGroup("team", "team commands")]
    internal class TeamCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;
        private readonly ITeamRepository _repo;

        public TeamCommands(IMediator mediator, ITeamRepository repo)
        {
            _mediator = mediator;
            _repo = repo;
        }

        [SlashCommand("create", "Creates a new racing team with Discord roles and channels")]
        public async Task CreateCommand(InteractionContext ctx, [Option("name", "Give your team a cool name")] string name)
        {
            var response = await _mediator.Send(new TeamCreateRequest
            {
                GuildId = ctx.Guild.Id.ToString(),
                Name = name,
                Username = ctx.User.Username,
                When = DateTime.Now
            });

            var msg = new DiscordInteractionResponseBuilder()
                .WithContent($"New team __{name}__ created");

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, msg);
        }
    }
}
