using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Unlockables
    {
        public string Name { get; set; }
        private DateTime Validity { get; set; }
        public bool Active { get; set; }

        public string ExpiresOn => Validity.ToString("dd/MM/yyyy");

        public Unlockables(string name, DateTime validity)
        {
            Name = name;
            Validity = validity;
        }
    }
}
