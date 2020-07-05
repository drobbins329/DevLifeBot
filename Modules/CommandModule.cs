using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevLifeBot.Modules
{
    class CommandModule : ModuleBase<SocketCommandContext>
    {
        [Command("author")]
        [Summary("reply with command Author info")]
        public async Task authorCommand()
        {
            try
            {
                string message =  "";
                message += Context.User.Username;
                message += "\n";
                message += Context.User.Id;
                message += "\n";
                SocketGuildUser author = (SocketGuildUser)Context.User;
                foreach (SocketRole role in author.Roles)
                { message += string.Format("\n" + role.Name); }
                await Context.Message.Channel.SendMessageAsync(message);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); await Context.Message.Channel.SendMessageAsync("Sorry, something went wrong. :( "); }
            await Context.Message.DeleteAsync();
        }
    }
}
