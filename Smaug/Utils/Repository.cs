using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smaug.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using NHibernate;
    using NHibernate.Linq;
    using Ninject;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;
        private readonly IKernel _kernel;

        public Repository(ISession session, IKernel kernel)
        {
            _session = session;
            _kernel = kernel;
        }

        public Repository()
        {
        }

        public bool Add(T entity)
        {
            _session.Save(entity);
            _session.Flush();
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            _session.Flush();
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            _session.Flush();

            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            _session.Flush();
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            _session.Flush();
            return true;
        }

        public T FindBy(int id)
        {
            _session.CacheMode = CacheMode.Normal;
            return _session.Get<T>(id);
        }

        public T FindBy<TV>(TV id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).FirstOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

    }
}
