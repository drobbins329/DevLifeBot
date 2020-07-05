using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DevLifeBot.Handlers
{
    class ReactionAddedHandler
    {
        private readonly DiscordSocketClient _client;

        public ReactionAddedHandler(DiscordSocketClient client)
        {            
            _client = client;
        }

        public async Task InstallReactionAddedHandlerAsync()
        {
            _client.ReactionAdded += HandleReactionAddedAsync;
        }

        private async Task HandleReactionAddedAsync(Cacheable<IUserMessage, ulong> reactionMessage, ISocketMessageChannel reactionChannel, SocketReaction reaction)
        {
            if (reaction.Emote.ToString() == "🤔")
            {
                ISocketMessageChannel replyChannel = reaction.Channel;
                await replyChannel.SendMessageAsync("I saw that!");
            }
        }
    }
}
