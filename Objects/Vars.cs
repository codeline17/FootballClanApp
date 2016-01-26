using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public static class Vars
    {
        public static string ConnectionString;

        public static void Init(string connectionstring)
        {
            ConnectionString = connectionstring;
        }
    }
}
