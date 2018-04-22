﻿using Discord;
using Discord.Audio;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace DiscordAPI
{
    public static class DiscordClient
    {
        private static DiscordSocketClient bot;
        private static IAudioClient audioClient;
        private static AudioOutStream voiceStream;
        public static string FFLogsToken;

        public delegate void Trigger();
        public static Trigger BotReady;
        public static Trigger LoginFail;

        public delegate void BotMessage(string message);
        public static BotMessage Log;

        public static async void InIt(string logintoken, string fflogstoken)
        {
            FFLogsToken = fflogstoken;
            try
            {
                bot = new DiscordSocketClient(new DiscordSocketConfig
                {
                    WebSocketProvider = WS4NetProvider.Instance
                });
            }
            catch (NotSupportedException)
            {
                Log("Unsupported Operating System.");
            }

            try
            {
                bot.Ready -= Bot_Ready;
                bot.Ready += Bot_Ready;
                await bot.LoginAsync(TokenType.Bot, logintoken);
                await bot.StartAsync();
                //need to wait to double check login issues
                //as exceptions are not always thrown
                await Task.Delay(10000);
                if (!IsConnected())
                    LoginFail?.Invoke();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                LoginFail?.Invoke();
            }
        }

        public static async Task deInIt()
        {
            bot.Ready -= Bot_Ready;
            bot.MessageReceived -= Bot_MessageReceived;
            if (audioClient?.ConnectionState == ConnectionState.Connected)
            {
                voiceStream?.Close();
                await audioClient.StopAsync();
            }
            await bot.StopAsync();
            await bot.LogoutAsync();
        }

        public static bool IsConnected()
        {
            return bot?.ConnectionState == ConnectionState.Connected;
        }

        private static async Task Bot_Ready()
        {
            commands = new CommandService();
            services = new ServiceCollection().BuildServiceProvider();
            await commands.AddModuleAsync(typeof(DiscordTriggers));
            bot.MessageReceived += Bot_MessageReceived;
            await bot.SetGameAsync("with ACT Triggers");
            BotReady?.Invoke();
            bot.Ready -= Bot_Ready;
        }

        public static string[] getServers()
        {
            try
            {
                List<string> servers = new List<string>();
                foreach (SocketGuild g in bot.Guilds)
                    servers.Add(g.Name);

                return servers.ToArray();
            }
            catch (Exception)
            {
                return new string[0];
            }
        }

        public static string[] getChannels(string server)
        {
            List<string> discordchannels = new List<string>();

            foreach (SocketGuild g in bot.Guilds)
            {
                if (g.Name == server)
                {
                    var channels = new List<SocketVoiceChannel>(g.VoiceChannels);
                    channels.Sort((x, y) => x.Position.CompareTo(y.Position));
                    foreach (SocketVoiceChannel channel in channels)
                        discordchannels.Add(channel.Name);
                    return discordchannels.ToArray();
                }
            }

            return new string[0];
        }

        private static SocketVoiceChannel[] getSocketChannels(string server)
        {
            List<SocketVoiceChannel> discordchannels = new List<SocketVoiceChannel>();

            foreach (SocketGuild g in bot.Guilds)
            {
                if (g.Name == server)
                {
                    var channels = new List<SocketVoiceChannel>(g.VoiceChannels);
                    channels.Sort((x, y) => x.Position.CompareTo(y.Position));
                    foreach (SocketVoiceChannel channel in channels)
                        discordchannels.Add(channel);
                    return discordchannels.ToArray();
                }
            }

            return null;
        }

        public static void SetGameAsync(string text)
        {
            bot.SetGameAsync(text);
        }

        public static async Task<bool> JoinChannel(string server, string channel)
        {
            SocketVoiceChannel chan = null;

            foreach(SocketVoiceChannel vchannel in getSocketChannels(server))
                if (vchannel.Name == channel)
                    chan = vchannel;

            if(chan != null)
            {
                try
                {
                    audioClient =  await chan.ConnectAsync();
                    Log?.Invoke("Joined channel: " + chan.Name);
                }
                catch(Exception e)
                {
                    Log(e.Message);
                    return false;
                }
            }
            return true;
        }

        public static async void LeaveChannel()
        {
            voiceStream?.Close();
            voiceStream = null;
            if(audioClient.ConnectionState == ConnectionState.Connected)
                await audioClient.StopAsync();
        }

        public static async void SendChannelMessage(ulong id, string message)
        {
            var channel = bot.GetChannel(id) as SocketTextChannel;

            await channel.SendMessageAsync(message);
        }

        private static CommandService commands;
        private static IServiceProvider services;
        private static char prefix = '!';

        private static async Task Bot_MessageReceived(SocketMessage arg)
        {
            SocketUserMessage msg = arg as SocketUserMessage;

            if (msg == null)
                return;

            int pos = 0;

            var content = new CommandContext(bot, msg);

            if (msg.HasStringPrefix("https://www.fflogs.com/character/id/", ref pos))
                await DiscordTriggers.getFFLogsFromLink(msg.Content, content);

            if (!(msg.HasCharPrefix(prefix, ref pos) || msg.HasMentionPrefix(bot.CurrentUser, ref pos)))
                return;

            var result = await commands.ExecuteAsync(content, pos, services);
#if DEBUG
            if (!result.IsSuccess)
                Log(result.ErrorReason + " : " + msg.Content);
#endif
            await msg.DeleteAsync();
        }

        private static object speaklock = new object();
        private static SpeechAudioFormatInfo formatInfo = new SpeechAudioFormatInfo(48000, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);

        public static void Speak(string text,string voice, int vol, int speed)
        {
            lock (speaklock)
            {
                if (voiceStream == null)
                    voiceStream = audioClient.CreatePCMStream(AudioApplication.Voice, 128 * 1024);
                SpeechSynthesizer tts = new SpeechSynthesizer();
                tts.SelectVoice(voice);
                tts.Volume = vol * 5;
                tts.Rate = speed - 10;
                MemoryStream ms = new MemoryStream();
                tts.SetOutputToAudioStream(ms, formatInfo);

                tts.Speak(text);
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(voiceStream);
                voiceStream.Flush();
            }
        }

        public static void SpeakFile(string path)
        {
            lock (speaklock)
            {
                if (voiceStream == null)
                    voiceStream = audioClient.CreatePCMStream(AudioApplication.Voice, 128 * 1024);
                try
                {
                    WaveFileReader wav = new WaveFileReader(path);
                    WaveFormat waveFormat = new WaveFormat(48000, 16, 2);
                    WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(wav);
                    WaveFormatConversionStream output = new WaveFormatConversionStream(waveFormat, pcm);
                    output.CopyTo(voiceStream);
                    voiceStream.Flush();
                }
                catch (Exception ex)
                {
                    Log("Unable to read file: " + ex.Message);
                }
            }
        }

        public static bool SendChannelMessage(string message,ulong channelID)
        {
            try
            {
                var channel = bot.GetChannel(channelID) as SocketTextChannel;
                if (channel != null)
                    channel.SendMessageAsync(message);
                else
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
