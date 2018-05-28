using Ninject.Modules;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Infrastructure
{
    public class connectNinject : NinjectModule
    {
        private string connectionString;

        public connectNinject(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
           
        }
    }
}
