using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);

        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
