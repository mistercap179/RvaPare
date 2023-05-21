using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class MainViewModel
    {
        private Konekcija konekcija = new Konekcija();
        private readonly IService service;

        public StudentViewModel StudentViewModel { get; }
        public PredmetViewModel PredmetViewModel { get; }

        public MainViewModel()
        {
            service = konekcija.serviceKonekcija();

            StudentViewModel = new StudentViewModel(service);
            PredmetViewModel = new PredmetViewModel(service);
        }
    }
}
