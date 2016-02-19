﻿using System;
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

        public int PointsWon => Outcomes.Count(x => x.isWon) * Value;


        public Game(string name, string slug, List<Outcome> outcomes, string repeater)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
            Repeater = repeater;
        }

        public Game(string name, string slug, List<Outcome> outcomes, string repeater, int value)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
            Repeater = repeater;
            Value = value;
        }

        public void AddOutcome(Outcome outcome)
        {
            Outcomes.Add(outcome);
        }

        public Game()
        {
            
        }
    }
}
