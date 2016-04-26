using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Ninject;
using Smaug.Models;

namespace Smaug.Utils
{
    public class MyConsole : Repository<League>
    {
        private frmMain main;

        public MyConsole(ISessionFactory s, IKernel k) : base()
        {
            
        }
        public void WriteLine(string msg)
        {
            //main.AppendText(msg);

            var l = new League
            {
                Id = 1,
                Name = "test"
            };
            Add(l);

        }
    }
}
