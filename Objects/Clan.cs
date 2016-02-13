﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Clan
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Leader { get; set; }

        public int UserCount { get; set; }

        public Clan(string name, List<User> users, DateTime createdOn, string leader, int usercount)
        {
            Name = name;
            Users = users;
            CreatedOn = createdOn;
            Leader = leader;
            UserCount = usercount;
        }

        public Clan(string name, int usercount, string leader)
        {
            Name = name;
            UserCount = usercount;
            Leader = leader;
            Users = new List<User>();
        }

        public Clan()
        {
            Users = new List<User>();
        }
    }
}
