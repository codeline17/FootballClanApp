using System;
using System.Collections.Generic;
using System.Linq;
using Smaug.Models;
using System.Xml.Linq;
using System.Diagnostics;
using NHibernate.Util;
using Smaug.Interfaces;
using Smaug.Utils;

namespace Smaug.Controller
{
    public static class FeedController
    {
        public static void GeneralParse(XDocument d)
        {
            try
            {
                if (d?.Root == null)
                {
                    Console.WriteLine("Xml is null");
                    return;
                }
                var country = d.Root.Attribute("country").Value; 

                var leagues = d.Root.Descendants().Where(de => de.Name == "league" && de.HasAttributes);
                ProcessLeagues(leagues, country);

                var teams = d.Root.Descendants().Where(de => (de.Name == "home" || de.Name =="away") && de.HasAttributes);
                ProcessTeams(teams);

                var matches = d.Root.Descendants().Where(de => de.Name == "match" && de.HasAttributes);
                ProcessMatches(matches);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                Console.WriteLine($"Stack : {e.StackTrace}");
            }
        }
        private static void ProcessTeams(IEnumerable<XElement> teams)
        {
            var teamList = new List<ITeam>();

            foreach (var t in teams)
            {
                var parentLeague = t.FindParent("league")?.Attribute("name").Value;
                                
                switch (t.Name.ToString())
                {
                    case "home":
                        var h = new Home
                        {
                            Id = t.Attribute("id").Value,
                            Name = t.Attribute("name").Value,
                            Country = parentLeague ?? "NoLeague"
                        };
                        teamList.Add(h);
                        break;
                    case "away":
                        var a = new Home
                        {
                            Id = t.Attribute("id").Value,
                            Name = t.Attribute("name").Value,
                            Country = parentLeague ?? "NoLeague"
                        };
                        teamList.Add(a);
                        break;
                    default:
                        Console.WriteLine($"Special node name : {t.Name.ToString()}");
                        break;
                }
            }

#if DEBUG
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} >> {teamList.Count()} teams were found.");
#endif
            teamList.SaveOrUpdate();
        }
        private static void ProcessLeagues(IEnumerable<XElement> leagues, string country)
        {
            var leagueList = leagues.Select(l => new League
            {
                Name = l.Attribute("name").Value, Sub_id = l.Attribute("sub_id").Value != "" ? l.Attribute("sub_id").Value : l.Attribute("id").Value, Country = country ?? "NoCountry"
            }).ToList();

#if DEBUG
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} >> {leagueList.Count()} leagues were found.");
#endif
            leagueList.SaveOrUpdate();
        }
        private static void ProcessMatches(IEnumerable<XElement> matches)
        {
            var matchList = matches.Select(m => new Match
            {
                Static_id = m.Attribute("static_id").Value,
                HomeId = m.Element("home")?.Attribute("id").Value,
                AwayId = m.Element("away")?.Attribute("id").Value,
                Date = m.Attribute("date").Value,
                Time = m.Attribute("time").Value,
                Status = m.Attribute("status").Value,
                Id = m.Attribute("id").Value,
                LeagueId = m.FindParent("league")?.Attribute("sub_id")?.Value ?? m.FindParent("league")?.Attribute("id")?.Value
            }).ToList();

#if DEBUG
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} >> {matchList.Count()} matches were found.");
#endif
            matchList.SaveOrUpdate();
        }

        //HL
        public static void HighlightParse(XDocument d)
        {
            try
            {
                if (d?.Root == null)
                {
                    Console.WriteLine("Xml is null");
                    return;
                }
                var matches = d.Root.Descendants().Where(de => de.Name == "match" && de.HasAttributes);
                ProcessHLMatches(matches);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
                Console.WriteLine($"Stack : {e.StackTrace}");
            }
        }
         
        private static void ProcessHLMatches(IEnumerable<XElement> matches)
        {
            var matchList = matches.Select(m => new Match
            {               
                Static_id = m.Attribute("static_id").Value,
                Status = m.Attribute("status")?.Value ?? "ToGo",
                Id = m.Attribute("id").Value,
                Date = m.Attribute("date").Value,
                Time = m.Attribute("time").Value,
                HomeGoals = m.Descendants()?.FirstOrDefault(h => h.HasAttributes && (h.Name == "home" || h.Name == "localteam"))?.Attribute("goals")?.Value.Replace("?","0") ?? "0",
                AwayGoals = m.Descendants()?.FirstOrDefault(h => h.HasAttributes && (h.Name == "away" || h.Name == "visitorteam"))?.Attribute("goals")?.Value.Replace("?", "0") ?? "0",
                Events = m.Descendants("event")?.Select(e => new Event
                {
                    Id = e.Attribute("id")?.Value.ToInt(0) ?? 0,
                    Minute = e.Attribute("minute")?.Value,
                    Type = e.Attribute("type")?.Value,
                    Team = e.Attribute("team")?.Value,
                    Player = new Player
                    {
                        Id = e.Attribute("playerid")?.Value,
                        Name = e.Attribute("player")?.Value,
                    }
                }
                ).ToList()
            }).ToList();

#if DEBUG
            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")} >> {matchList.Count()} matches were found.");
#endif
            matchList.Update();

        }
    }
}
