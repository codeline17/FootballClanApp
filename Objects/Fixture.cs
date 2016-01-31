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
        public int ID { get; set; }
        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public List<Event> Events { get; set; }

        public string Minute { get; set; }

        public Competition League { get; set; }

        public List<Game> Games { get; set; }

        public DateTime StartTime { get; set; }

        public string ShortTime => StartTime.ToString("HH:mm");

        public bool Sealed { get; set; }

        public Fixture(int id, Team hometeam, 
                        Team awayteam, List<Event> events, 
                        string minute, Competition league, 
                        List<Game> games, DateTime starttime, bool mSealed)
        {
            ID = id;
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            Events = events;
            Minute = minute;
            League = league;
            Games = games;
            StartTime = starttime;
            Sealed = mSealed;
        } 
    }

    public class Event
    {
        public string Type { get; set; }

        public int Value { get; set; }

        public string Minute { get; set; }

        public Event(string type, int value, string minute)
        {
            Type = type;
            Value = value;
            Minute = minute;
        }
    }
}
