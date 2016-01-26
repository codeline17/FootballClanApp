using System;
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

        public Clan(string name, List<User> users, DateTime createdOn)
        {
            Name = name;
            Users = users;
            CreatedOn = createdOn;
        }
    }
}
