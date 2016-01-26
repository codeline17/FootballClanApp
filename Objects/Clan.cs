using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Clan
    {
        private string _name;
        private List<User> _users;
        private DateTime _createdOn;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        public Clan(string name, List<User> users, DateTime createdOn)
        {
            Name = name;
            Users = users;
            CreatedOn = createdOn;
        }
    }
}
