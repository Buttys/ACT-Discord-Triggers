﻿using Discord;
using Discord.Commands;
using DiscordAPI.JsonWrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiscordAPI
{
    public class DiscordTriggers : ModuleBase
    {

        private static HttpClient NewClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static async Task GetFFLogsFromLink(string link, ICommandContext Context)
        {
            try
            {
                string[] parts = link.Split('/');
                string charname;
                string charserver;
                if (parts.Length == 6)
                {
                    //required for char profiles
                    //unlikly to be used but just in case
                    //example - https://www.fflogs.com/character/id/180987
                    var url = new Uri(link);
                    HttpClient client = NewClient();
                    string responseBody = await client.GetStringAsync(url);
                    charname = Between(responseBody, "<div id=\"character-name\">", "</div>");
                    string region = Between(responseBody, string.Format("<a id=\"server-link\" href=\"/server/id/{0}\">", Between(responseBody, "<a id=\"server-link\" href=\"/server/id/", "\">")), "</a>");
                    charserver = region.Split('-')[1];
                }
                else
                {
                    charname = parts[6];
                    charserver = parts[5];
                }

                await GetFFLogs(charserver, charname, Context.Channel.Id);
            }
            catch
            {
                await Context.Channel.SendMessageAsync(string.Format("Failed to load - {0}",link));
            }
        }

        private static string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);

            if (posA == -1)
                return string.Empty;

            int adjustedPosA = posA + a.Length;

            string valueStart = value.Substring(adjustedPosA);

            int posB = valueStart.IndexOf(b);

            if (posB == -1)
                return string.Empty;
            return value.Substring(adjustedPosA, posB);
        }

        [Command("fflogs")]
        [Summary("Drellis speciality")]
        public async Task Fflogs(string server, [Remainder] string name)
        {
            await GetFFLogs(server, name, Context.Channel.Id);
        }

        [Command("fflog")]
        [Summary("Drellis speciality")]
        public async Task Fflog(string server, [Remainder] string name)
        {
            await GetFFLogs(server, name, Context.Channel.Id);
        }

        public static async Task GetFFLogs(string server, string name, ulong channel)
        {

            var worlds = Worlds.GetWorlds();
            var worldResult = from wrld in worlds
                              where wrld.Name.ToLower().Contains(server.ToLower())
                              select wrld;
            var world = worldResult.First();





            var url = new Uri($"https://www.fflogs.com/v1/parses/character/{name}/{world.Name}/{world.Region}/?api_key={DiscordClient.FFLogsToken}");
            HttpClient client = NewClient();
            string responseBody;

            try
            {
                responseBody = await client.GetStringAsync(url);
            }
            catch (Exception)
            {
                DiscordClient.SendChannelMessage($"No parses found for {name} or Incorrect FFLogs Token.", channel);
                return;
            }
            List<Parses> parses = new List<Parses>();

            try
            {
                parses = JsonConvert.DeserializeObject<List<Parses>>(responseBody);
            }
            catch
            {
                DiscordClient.SendChannelMessage($"Hidden parses detected, {name} is a scrub.", channel);
                return;
            }

            StringBuilder des = new StringBuilder();

            if (parses.Count == 0)
                des.AppendLine("No encounters found.");

            string charname = string.Empty;
            Dictionary<string, List<Parses>> parseData = new Dictionary<string, List<Parses>>();

            foreach (Parses parse in parses)
            {
                if (string.IsNullOrEmpty(charname))
                    charname = parse.characterName;

                if (parseData.ContainsKey(parse.encounterName))
                    parseData[parse.encounterName].Add(parse);
                else
                    parseData.Add(parse.encounterName, new List<Parses> { parse });
            }

            int encounters = 0;


            foreach(string key in parseData.Keys)
            {
                des.AppendLine($"__**{key} - Kills : {parseData[key].Count}**__");
                Dictionary<string, List<Parses>> classData = new Dictionary<string, List<Parses>>();
                foreach(Parses parse in parseData[key])
                {
                    if (classData.ContainsKey(parse.spec))
                        classData[parse.spec].Add(parse);
                    else
                        classData.Add(parse.spec, new List<Parses> { parse });
                }
                
                foreach(string spec in classData.Keys)
                {
                    int highestPercentile = 0;
                    int avgPercentile = 0;
                    double highestdps = 0;
                    int time = 0;
                    foreach(Parses parse in classData[spec])
                    {
                        if (parse.percentile > highestPercentile)
                        {
                            highestPercentile = parse.percentile;
                            highestdps = parse.total;
                        }
                        avgPercentile += parse.percentile;
                        if (time == 0)
                            time = parse.duration;
                        else if (parse.duration < time)
                            time = parse.duration;
                    }
                    if (classData[spec].Count > 0)
                    {
                        avgPercentile = avgPercentile / classData[spec].Count;
                        encounters++;
                        List<Parses> data = classData[spec].OrderBy(o => o.percentile).ToList();
                        des.AppendLine($"{GetJob(spec)} Best Clear <{string.Format("{0:0.#}", highestdps)}>  Best Time - {String.Format("{0:mm\\:ss}", TimeSpan.FromMilliseconds(time))}");
                    }
                }
            }
            

            var embed = new EmbedBuilder()
            .WithTitle($"Current Savage Data - FFLogs")
            .WithUrl(new Uri($"https://www.fflogs.com/character/{world.Region}/{world.Name}/{name}").AbsoluteUri)
            .WithThumbnailUrl("https://i.imgur.com/lNX3xcv.jpg")
            //.WithImageUrl("https://i.imgur.com/lNX3xcv.jpg")
            .WithFooter(new EmbedFooterBuilder()
            .WithText($"{(string.IsNullOrEmpty(charname) ? name:charname)} - {world.Name} - {world.Region}"))
            .WithColor(new Color(102, 255, 222))
            .WithDescription(des.ToString())
            .Build();

            DiscordClient.SendChannelEmbed(embed, channel);
        }

        private static string GetJob(string name)
        {
            switch (name)
            {
                case "White Mage":
                    return "<:whm:343479909160583168>";
                case "Astrologian":
                    return "<:ast:343479455005540353>";
                case "Scholar":
                    return "<:sch:343479909236080640>";
                case "Paladin":
                    return "<:pld:343479908854661121>";
                case "Warrior":
                    return "<:war:343479908879826945>";
                case "Dark Knight":
                    return "<:drk:343479908980359168>";
                case "Bard":
                    return "<:brd:343479908757929995>";
                case "Machinist":
                    return "<:mch:343479908879826955>";
                case "Black Mage":
                    return "<:blm:343479267394322433>";
                case "Red Mage":
                    return "<:rdm:343479908741283852>";
                case "Summoner":
                    return "<:smn:343479908900667394>";
                case "Dragoon":
                    return "<:drg:343479908632231937>";
                case "Monk":
                    return "<:mnk:492354384873652224>";
                case "Ninja":
                    return "<:nin:343479908850466818>";
                case "Samurai":
                    return "<:sam:343479909043273730>";
                case "Dancer":
                    return "<:dnc:599736106400874507>";
                case "Gunbreaker":
                    return "<:gnb:599737249676132393>";
                default:
                    return ":poop:";
            }
        }

        [Command("status")]
        [Summary("Drellis speciality")]
        public async Task Status([Remainder] string text)
        {
            DiscordClient.SetGameAsync(text);
            await Context.Channel.SendMessageAsync($"Status updated to - Playing {text}");
        }


    }
}
