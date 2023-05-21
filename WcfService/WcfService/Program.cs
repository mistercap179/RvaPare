using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService.DBCrud;

namespace WcfService
{
    class Program
    {

        static void Main(string[] args)
        {
            /*   Models.Konekcije.ServerKonekcija<IService> konekcija =
                   new Models.Konekcije.ServerKonekcija<IService>(
                       new string[] { Models.Konekcije.Konekcija.UriServer },
                       new Service(new DBCrud.DBCrud())
                   );
               konekcija.Open();*/

            /*var ServerPort = 12341;
            var UriServer = $"net.tcp://localhost:{ServerPort}/Service";*/
            var serverAdress = "127.0.0.1:1000";
            var UriServer = $"net.tcp://{serverAdress}/Service";

            var host = new ServiceHost(typeof(Service), new Uri(UriServer));
            var serverBinding = new NetTcpBinding();

            host.AddServiceEndpoint(typeof(IService), serverBinding, "");
            host.Open();


            Console.ReadLine();
        }
    }
}
