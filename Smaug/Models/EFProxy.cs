using System.Xml.Serialization;
using System.Collections.Generic;
using Smaug.Interfaces;

namespace Smaug.Models
{

    [XmlRoot(ElementName = "league")]
    public class League
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "season")]
        public string Season { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "sub_id")]
        public string Sub_id { get; set; }

        [XmlElement(ElementName = "stage")]
        public List<Stage> Stage { get; set; }
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "home")]
    public class Home : ITeam
    {
        [XmlAttribute(AttributeName = "et_score")]
        public string Et_score { get; set; }
        [XmlAttribute(AttributeName = "ft_score")]
        public string Ft_score { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "pen_score")]
        public string Pen_score { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlElement(ElementName = "player")]
        public List<Player> Player { get; set; }
        [XmlElement(ElementName = "substitution")]
        public List<Substitution> Substitution { get; set; }
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "away")]
    public class Away : ITeam
    {
        [XmlAttribute(AttributeName = "et_score")]
        public string Et_score { get; set; }
        [XmlAttribute(AttributeName = "ft_score")]
        public string Ft_score { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "pen_score")]
        public string Pen_score { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlElement(ElementName = "player")]
        public List<Player> Player { get; set; }
        [XmlElement(ElementName = "substitution")]
        public List<Substitution> Substitution { get; set; }
        public string Country { get; set; }
    }

    [XmlRoot(ElementName = "halftime")]
    public class Halftime
    {
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
    }

    [XmlRoot(ElementName = "match")]
    public class Match
    {
        [XmlElement(ElementName = "home")]
        public Home Home { get; set; }
        [XmlElement(ElementName = "away")]
        public Away Away { get; set; }
        [XmlElement(ElementName = "halftime")]
        public Halftime Halftime { get; set; }
        [XmlAttribute(AttributeName = "alternate_id")]
        public string Alternate_id { get; set; }
        [XmlAttribute(AttributeName = "alternate_id_2")]
        public string Alternate_id_2 { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "static_id")]
        public string Static_id { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlAttribute(AttributeName = "venue")]
        public string Venue { get; set; }
        [XmlAttribute(AttributeName = "venue_city")]
        public string Venue_city { get; set; }
        [XmlAttribute(AttributeName = "venue_id")]
        public string Venue_id { get; set; }
        [XmlElement(ElementName = "goals")]
        public Goals Goals { get; set; }
        [XmlElement(ElementName = "lineups")]
        public Lineups Lineups { get; set; }
        [XmlElement(ElementName = "substitutions")]
        public Substitutions Substitutions { get; set; }
    }

    [XmlRoot(ElementName = "aggregate")]
    public class Aggregate
    {
        [XmlElement(ElementName = "match")]
        public List<Match> Match { get; set; }
        [XmlAttribute(AttributeName = "firstteam")]
        public string Firstteam { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlAttribute(AttributeName = "secondteam")]
        public string Secondteam { get; set; }
        [XmlAttribute(AttributeName = "winner")]
        public string Winner { get; set; }
    }

    [XmlRoot(ElementName = "stage")]
    public class Stage
    {
        [XmlElement(ElementName = "aggregate")]
        public List<Aggregate> Aggregate { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "round")]
        public string Round { get; set; }
        [XmlAttribute(AttributeName = "stage_id")]
        public string Stage_id { get; set; }
        [XmlElement(ElementName = "match")]
        public Match Match { get; set; }
        [XmlElement(ElementName = "week")]
        public List<Week> Week { get; set; }
    }

    [XmlRoot(ElementName = "goal")]
    public class Goal
    {
        [XmlAttribute(AttributeName = "assist")]
        public string Assist { get; set; }
        [XmlAttribute(AttributeName = "minute")]
        public string Minute { get; set; }
        [XmlAttribute(AttributeName = "player")]
        public string Player { get; set; }
        [XmlAttribute(AttributeName = "playerid")]
        public string Playerid { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlAttribute(AttributeName = "team")]
        public string Team { get; set; }
    }

    [XmlRoot(ElementName = "goals")]
    public class Goals
    {
        [XmlElement(ElementName = "goal")]
        public List<Goal> Goal { get; set; }
    }

    [XmlRoot(ElementName = "player")]
    public class Player
    {
        [XmlAttribute(AttributeName = "booking")]
        public string Booking { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "lineups")]
    public class Lineups
    {
        [XmlElement(ElementName = "home")]
        public Home Home { get; set; }
        [XmlElement(ElementName = "away")]
        public Away Away { get; set; }
    }

    [XmlRoot(ElementName = "substitution")]
    public class Substitution
    {
        [XmlAttribute(AttributeName = "minute")]
        public string Minute { get; set; }
        [XmlAttribute(AttributeName = "player_in_booking")]
        public string Player_in_booking { get; set; }
        [XmlAttribute(AttributeName = "player_in_id")]
        public string Player_in_id { get; set; }
        [XmlAttribute(AttributeName = "player_in_name")]
        public string Player_in_name { get; set; }
        [XmlAttribute(AttributeName = "player_in_number")]
        public string Player_in_number { get; set; }
        [XmlAttribute(AttributeName = "player_out_id")]
        public string Player_out_id { get; set; }
        [XmlAttribute(AttributeName = "player_out_name")]
        public string Player_out_name { get; set; }
    }

    [XmlRoot(ElementName = "substitutions")]
    public class Substitutions
    {
        [XmlElement(ElementName = "home")]
        public Home Home { get; set; }
        [XmlElement(ElementName = "away")]
        public Away Away { get; set; }
    }

    [XmlRoot(ElementName = "week")]
    public class Week
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "extended_fixtures")]
    public class EFProxy
    {
        [XmlElement(ElementName = "league")]
        public List<League> League { get; set; }
        [XmlAttribute(AttributeName = "updated")]
        public string Updated { get; set; }
        [XmlAttribute(AttributeName = "sport")]
        public string Sport { get; set; }
        [XmlAttribute(AttributeName = "country")]
        public string Country { get; set; }
    }
}
