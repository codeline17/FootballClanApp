using System;
using System.Collections.Generic;

namespace Objects
{
    public class League
    {
        private string _name;
        private int _leagueType;
        private List<User> _users;
        private List<Clan> _clans;
        private DateTime _startDate;
        private DateTime _endDate;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LeagueType
        {
            get { return _leagueType; }
            set { _leagueType = value; }
        }

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public List<Clan> Clans
        {
            get { return _clans; }
            set { _clans = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
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
