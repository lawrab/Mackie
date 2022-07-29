using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace SnailRacing.Mackie.Discord
{
    internal class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("ping", "Responds with Pong")]
        public async Task PingCommand(InteractionContext ctx, [Option("user", "User to ping")] DiscordUser user) 
        {
            var msg = new DiscordInteractionResponseBuilder()
                .WithContent($"{user.Mention} {ctx.Member.Mention} asked me to ping you, hope you have a great day!");

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, msg);
        }
    }
}
