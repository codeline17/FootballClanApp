using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smaug.Models;
using System.Xml.Linq;
using System.Diagnostics;
using Smaug.Bases;
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
                if (d == null || d.Root == null)
                {
                    Debug.WriteLine("Xml is null");
                    return;
                }
                var country = d.Root.Attribute("country").Value; 

                var leagues = d.Root.Descendants("league");
                ProcessLeagues(leagues, country);

                var teams = d.Root.Descendants().Where(de => (de.Name == "home" || de.Name =="away") && de.HasAttributes);
                ProcessTeams(teams);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error : {e.Message}");
                Debug.WriteLine($"Stack : {e.StackTrace}");
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
                        var h = new Home();
                        h.Id = t.Attribute("id").Value;
                        h.Name = t.Attribute("name").Value;
                        h.Country = parentLeague ?? "NoLeague";
                        teamList.Add(h);
                        break;
                    case "away":
                        var a = new Home();
                        a.Id = t.Attribute("id").Value;
                        a.Name = t.Attribute("name").Value;
                        a.Country = parentLeague ?? "NoLeague";
                        teamList.Add(a);
                        break;
                    default:
                        Debug.WriteLine($"Special node name : {t.Name.ToString()}");
                        break;
                }
            }

#if DEBUG
            Debug.WriteLine($"{teamList.Count()} teams were found.");
#endif
            teamList.SaveOrUpdate();
        }

        private static void ProcessLeagues(IEnumerable<XElement> leagues, string country)
        {
            var leagueList = new List<League>();

            foreach (var l in leagues)
            {
                leagueList.Add(
                   new League
                   {
                       Name = l.Attribute("name").Value,
                       Sub_id = l.Attribute("sub_id").Value != "" ? l.Attribute("sub_id").Value : l.Attribute("id").Value,
                       Country = country ?? "NoCountry"
                   }
                    );
            }

#if DEBUG
            Debug.WriteLine($"{leagueList.Count()} leagues were found.");
#endif
            leagueList.SaveOrUpdate();
        }


    }
}
