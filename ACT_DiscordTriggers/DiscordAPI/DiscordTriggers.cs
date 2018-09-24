using Discord;
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

        public static async Task getFFLogsFromLink(string link, ICommandContext Context)
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

                await getFFLogs(charserver, charname, Context);
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
            await getFFLogs(server, name, Context);
        }

        [Command("fflog")]
        [Summary("Drellis speciality")]
        public async Task Fflog(string server, [Remainder] string name)
        {
            await getFFLogs(server, name, Context);
        }

        public static async Task getFFLogs(string server, string name, ICommandContext Context)
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
                await Context.Channel.SendMessageAsync($"No parses found for {name} or Incorrect FFLogs Token.");
                return;
            }
            List<Parses> parses = new List<Parses>();

            try
            {
                parses = JsonConvert.DeserializeObject<List<Parses>>(responseBody);
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"Hidden parses detected, {name} is a scrub.");
                return;
            }

            StringBuilder des = new StringBuilder();

            if (parses.Count == 0)
                des.AppendLine("No encounters found.");


            Dictionary<string, List<Parses>> parseData = new Dictionary<string, List<Parses>>();
            string character = string.Empty;

            foreach (Parses parse in parses)
            {
                if (string.IsNullOrEmpty(character))
                    character = parse.characterName;
                if (parseData.ContainsKey(parse.encounterName))
                    parseData[parse.encounterName].Add(parse);
                else
                    parseData.Add(parse.encounterName, new List<Parses> { parse });
            }

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
                    int bestRank = 0;
                    int outOf = 0;
                    double highestdps = 0;
                    foreach(Parses parse in classData[spec])
                    {
                        if (parse.percentile > highestPercentile)
                        {
                            highestPercentile = parse.percentile;
                            highestdps = parse.total;
                        }
                        if (parse.rank < bestRank || bestRank == 0)
                            bestRank = parse.rank;
                        if (parse.outOf > outOf)
                            outOf = parse.outOf;
                        avgPercentile += parse.percentile;
                    }
                    if (classData[spec].Count > 0)
                    {
                        avgPercentile = avgPercentile / classData[spec].Count;
                        List<Parses> data = classData[spec].OrderBy(o => o.percentile).ToList();
                        int meanPercentile = data[(data.Count) / 2].percentile;
                        des.AppendLine($"{GetJob(spec)} DPS <{string.Format("{0:0.#}", highestdps)}> <{meanPercentile}-{avgPercentile}-{highestPercentile}>% Rank {bestRank} of {outOf}");
                    }
                }
            }
            

            var embed = new EmbedBuilder()
            .WithTitle($"Current Savage Data - FFLogs")
            .WithUrl(new Uri($"https://www.fflogs.com/character/{world.Region}/{world.Name}/{character}").AbsoluteUri)
            .WithThumbnailUrl("https://i.imgur.com/lNX3xcv.jpg")
            //.WithImageUrl("https://i.imgur.com/lNX3xcv.jpg")
            .WithFooter(new EmbedFooterBuilder()
            .WithText($"{character} - {world.Name} - {world.Region}"))
            .WithColor(new Color(102, 255, 222))
            .WithDescription(des.ToString())
            .Build();

            await Context.Channel.SendMessageAsync("", embed: embed);
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
                    return "<:mnk:492354531330490368>";
                case "Ninja":
                    return "<:nin:343479908850466818>";
                case "Samurai":
                    return "<:sam:343479909043273730>";
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
