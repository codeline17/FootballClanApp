using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

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
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int HomeYellow { get; set; }
        public int AwayYellow { get; set; }
        public int HomeRed { get; set; }
        public int AwayRed { get; set; }
        public int PointsWon => Games.Sum(x => x.PointsWon);
        public string Pack { get; set; }


        public Fixture(int id, Team hometeam, 
                        Team awayteam, List<Event> events, 
                        string minute, Competition league, 
                        List<Game> games, DateTime starttime, bool mSealed, string pack)
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
            Pack = pack;
        }

        public Fixture(Team hometeam, Team awayteam, Competition league, 
                        DateTime starttime, int homegoals, int awaygoals, 
                        int homeyellow, int awayyellow, int homered,
                        int awayred, string minute)
        {
            HomeTeam = hometeam;
            AwayTeam = awayteam;
            League = league;
            StartTime = starttime;
            HomeGoals = homegoals;
            AwayGoals = awaygoals;
            HomeYellow = homeyellow;
            AwayYellow = awayyellow;
            HomeRed = homered;
            AwayRed = awayred;
            Minute = minute;
            Games = new List<Game>();
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
