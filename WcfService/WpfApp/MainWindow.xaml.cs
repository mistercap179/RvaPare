﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IService service = Konekcija();

            service.deleteStudent(1);

        }


        public IService Konekcija()
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
