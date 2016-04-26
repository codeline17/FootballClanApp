using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Type;
using Ninject;
using Smaug.Utils;

namespace Smaug.Models
{
    public class League 
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Priority { get; set; }
        public virtual DateTime CreatedOn { get; set; }

        public League()
        { }
    }
}
