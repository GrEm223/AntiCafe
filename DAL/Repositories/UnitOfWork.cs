using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AccessContext accessContext;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Room> roomRepository;

        public UnitOfWork(string connectionString)
        {
            accessContext = new AccessContext(connectionString);
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository ==null)
                {
                    roomRepository = new GenericRepository<Room>(accessContext);
                }

                return roomRepository;
            }
               
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new GenericRepository<Order>(accessContext);

                }
                return orderRepository;
            }
        }

        public void Save()
        {
            accessContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    accessContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
