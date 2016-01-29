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

        public bool Sealed { get; set; }

        public Game(string name, string slug, List<Outcome> outcomes)
        {
            Name = name;
            Slug = slug;
            Outcomes = outcomes;
            SetSealed();
        }

        public void AddOutcome(Outcome outcome)
        {
            Outcomes.Add(outcome);
            SetSealed();
        }

        public void SetSealed()
        {
            Sealed = Outcomes.Any(x => x.Selected);
        }

        public Game()
        {
            
        }
    }
}
