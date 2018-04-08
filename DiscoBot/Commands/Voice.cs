﻿namespace DiscoBot.Commands
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Discord;
    using Discord.Audio;
    using Discord.Commands;

    public class Voice : ModuleBase
    {
        public static IAudioClient Client { get; set; }
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannelAsync(IVoiceChannel channel = null)
        {
            var msg = this.Context.Message;

            // Get the audio channel
            channel = channel ?? (msg.Author as IGuildUser)?.VoiceChannel;
            if (channel == null)
            {
                await msg.Channel.SendMessageAsync(
                    "User must be in a voice channel, or a voice channel must be passed as an argument.");
                return;
            }

            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            var audioClient = await channel.ConnectAsync();
            Client = audioClient;
        }

        [Command("leave", RunMode = RunMode.Async)]
        public Task LeaveChannelAsync(IVoiceChannel channel = null)
        {
            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            return Client.StopAsync();
        }

        [Command("play")]
        public Task PlayAudioAsync(string path)
        {
            return this.SendAsync(Client, path);
        }

        private Process CreateStream(string path)
        {
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-i {path}  -ac 2 -f s16le -ar 48000 -ab 620000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            return Process.Start(ffmpeg);
        }

        private async Task SendAsync(IAudioClient client, string path)
        {
            // Create FFmpeg using the previous example
            var ffmpeg = this.CreateStream(path);
            var output = ffmpeg.StandardOutput.BaseStream;
            var discord = client.CreatePCMStream(AudioApplication.Music);
            await output.CopyToAsync(discord);
            await discord.FlushAsync();
        }
    }
}
