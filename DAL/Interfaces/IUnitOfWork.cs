using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Room> Rooms { get;  }
        IRepository<Order> Orders { get;  }
        void Save();
    }
}
