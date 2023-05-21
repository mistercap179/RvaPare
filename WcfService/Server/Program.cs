using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerContainer.ConfigureContainer();       //Depedency injection

            var ServerPort = 12341;
            var UriServer = $"net.tcp://localhost:{ServerPort}/Service";

            var host = new ServiceHost(typeof(Service), new Uri(UriServer));
            var serverBinding = new NetTcpBinding();

            host.AddServiceEndpoint(typeof(IService), serverBinding, "");
            host.Open();

            Console.WriteLine("Server started.");
            Console.ReadLine();
        }
    }
}
