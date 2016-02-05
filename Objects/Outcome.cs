﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Outcome
    {
        public string Name;
        public bool Selected;
        public string Repeater;

        public Outcome(string name, bool selected, string repeater)
        {
            Name = name;
            Selected = selected;
            Repeater = repeater;
        }
    }
}
