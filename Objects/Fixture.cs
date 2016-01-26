using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Objects
{
    public class Fixture
    {
        private Team _homeTeam;
        private Team _awayTeam;
        private List<Event> _events;
        private string _minute;
        private League _league;


        public Team HomeTeam
        {
            get { return _homeTeam; }
            set { _homeTeam = value; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
            set { _awayTeam = value; }
        }

        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public string Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }

        public League League
        {
            get { return _league; }
            set { _league = value; }
        }

        public Fixture(Team hometeam, Team awayteam, List<Event> events, string minute, League league)
        {
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            Events = events;
            Minute = minute;
        }

    }

    public class Event
    {
        private string _type;
        private int _value;
        private string _minute;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }

        public Event(string type, int value, string minute)
        {
            Type = type;
            Value = value;
            Minute = minute;
        }
    }
}
