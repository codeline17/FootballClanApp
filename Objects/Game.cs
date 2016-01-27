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

        public Game(string name, string slug, List<Outcome> outcomes)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
        }

        public Game()
        {
            
        }
    }
}
