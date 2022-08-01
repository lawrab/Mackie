using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MediatR;
using SnailRacing.Mackie.Handlers.TeamHandlers;

namespace SnailRacing.Mackie.Discord
{
    internal class SlashCommands : ApplicationCommandModule
    {
        private readonly IMediator _mediator;

        public SlashCommands(IMediator mediator) => _mediator = mediator;

        [SlashCommand("ping", "Responds with Pong")]
        public async Task PingCommand(InteractionContext ctx, [Option("user", "User to ping")] DiscordUser user)
        {
            var response = await _mediator.Send(new TeamCreateRequest());

            var msg = new DiscordInteractionResponseBuilder()
                .WithContent($"{user.Mention} {ctx.Member.Mention} asked me to ping you, hope you have a great day!");

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, msg);
        }
    }
}
