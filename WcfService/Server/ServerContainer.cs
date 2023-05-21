using Server.DBCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Server
{
    public class ServerContainer
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container => _container;

        public static void ConfigureContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDBCrud, DBCrud.DBCrud>(new ContainerControlledLifetimeManager());
        }
    }
}
