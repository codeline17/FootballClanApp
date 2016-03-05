using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Game
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public List<Outcome> Outcomes { get; set; }

        public string Repeater { get; set; }

        public int Value { get; set; }
        public int Price { get; set; }
        public bool Authorized { get; set; }

        public int PointsWon => Outcomes.Count(x => x.isWon) * Value;


        public Game(string name, string slug, List<Outcome> outcomes, string repeater)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
            Repeater = repeater;
            Value = 0;
            Price = 0;
        }

        public Game(string name, string slug, List<Outcome> outcomes, string repeater, int value, int price, bool authorized)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
            Repeater = repeater;
            Value = value;
            Price = price;
            Authorized = authorized;
        }

        public void AddOutcome(Outcome outcome)
        {
            Outcomes.Add(outcome);
        }

        public Game()
        {
            Value = 0;
            Price = 0;
            Outcomes = new List<Outcome>();
        }
    }
}
