﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace DevLifeBot
{
    class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private DiscordSocketClient _client;

        public Startup(string[] args)
        {
            var Initialize = new Configuration(args);
        }

        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup(args);
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Verbose });

            var Initialize = new Configuration(null);
            string discordToken = Initialize.GetConfig("tokens:discord");   // reads bot token from _config.yml
            if (string.IsNullOrWhiteSpace(discordToken))
                throw new Exception("Please enter your bot's token into the `config.yaml` file found in the applications root directory.");
            
            await _client.LoginAsync(TokenType.Bot, discordToken);     // Login to discord
            await _client.StartAsync();

            await Task.Delay(-1);
        }
    }
}
