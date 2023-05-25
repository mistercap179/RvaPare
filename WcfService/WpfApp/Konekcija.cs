using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Konekcija
    {
        public IService serviceKonekcija()
        {
            var ServerPort = 12341;
            var UriServer = $"net.tcp://localhost:{ServerPort}/Service";

            Uri tcpUri = new Uri(UriServer);

            EndpointAddress address = new EndpointAddress(tcpUri);
            NetTcpBinding clientBinding = new NetTcpBinding();
            ChannelFactory<IService> channel = new ChannelFactory<IService>(clientBinding, address);

            IService service = channel.CreateChannel();
            
            return service;
        }
    }
}
