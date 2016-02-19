using System;
using System.Collections.Generic;

namespace Objects
{
    public class League
    {
        public string Name { get; set; }

        public int LeagueType { get; set; }

        public List<User> Users { get; set; }

        public List<Clan> Clans { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public League()
        {
            Clans = new List<Clan>();
            Users = new List<User>();
        }

        public League(string name, int leaguetype, List<User> users, DateTime startdate, DateTime enddate)
        {
            Name = name;
            LeagueType = leaguetype;
            Users = users;
            Clans = new List<Clan>();
            StartDate = startdate;
            EndDate = enddate;
        }
        public League(string name, int leaguetype, List<Clan> clans, DateTime startdate, DateTime enddate)
        {
            Name = name;
            LeagueType = leaguetype;
            Users = new List<User>();
            Clans = clans;
            StartDate = startdate;
            EndDate = enddate;
        }

    }


}
