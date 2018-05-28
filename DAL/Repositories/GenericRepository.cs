using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private AccessContext accessContext;
        private DbSet<T> dbSet;

        public GenericRepository(AccessContext context)
        {
            this.accessContext = context;
            this.dbSet = accessContext.Set<T>();
        }

        public void Create(T obj)
        {
            dbSet.Add(obj);
            accessContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
            accessContext.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        

        public void Update(T obj)
        {
           accessContext.Entry(obj).State = EntityState.Modified;
        }
    }
}
