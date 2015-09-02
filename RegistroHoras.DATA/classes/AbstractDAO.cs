using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes
{
    public abstract class AbstractDAO<T> where T : class
    {
        private Context _context = new Context();

        public void Add(T entity)
        {

            _context.Set<T>().Add(entity);



        }


        public Context GetContext()
        {
            if (_context != null)
                return _context;
            return new Context();
        }


        public void Delete(T entity)
        {

            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            CommitChanges();



        }

        public List<T> Find(Expression<Func<T, bool>> where)
        {

            return _context.Set<T>().Where<T>(where).ToList<T>();



        }


        public T Get(params Object[] keys)
        {


            return _context.Set<T>().Find(keys);


        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }

        public void Update(T updateEntity, object key)
        {
            var original = this.Get(key);
            if (original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(updateEntity);
                _context.SaveChanges();
            }

        }


        public void CommitChanges()
        {

            _context.SaveChanges();


        }
    }
}
