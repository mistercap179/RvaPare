using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class PredmetViewModel : INotifyPropertyChanged
    {
        private Konekcija konekcija = new Konekcija();
        private IService service { get; set; } = null;
        public ObservableCollection<string> ListBox { get; set; }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Models. Predmet> Predmeti { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public PredmetViewModel(IService service)
        {
            this.service = service;
            //service = konekcija.serviceKonekcija();
            AddCommand = new RelayCommand(AddPredmet);
            DeleteCommand = new RelayCommand<object>(DeletePredmet);
            ModifyCommand = new RelayCommand<object>(ModifyPredmet);
            SearchCommand = new RelayCommand(SearchPredmet);
            CancelCommand = new RelayCommand(CancelSearch); 
            ListBox = new ObservableCollection<string> { "naziv", "katedra", "profesor"};
            Predmeti = new ObservableCollection<Models.Predmet>(service.getPredmeti());
        }

        private void AddPredmet()
        {
            var addPredmetViewModel = new AddPredmetViewModel(service);
            var secondWindow = new AddPredmetView() { DataContext = addPredmetViewModel };
            secondWindow.Closed += SecondWindowClosed;
            secondWindow.Show();
        }

        private void DeletePredmet(object param)
        {
            if (param is Predmet item)
            {
                service.deletePredmet(item.Id);
                Predmeti.Remove(item);
            }
        }


        private void ModifyPredmet(object param)
        {
            if (param is Predmet item)
            {
                var modifyStudentViewModel = new ModifyPredmetViewModel(service, item);
                var secondWindow = new ModifyPredmetView() { DataContext = modifyStudentViewModel };

                secondWindow.Closed += SecondWindowClosed;
                secondWindow.Show();
            }

        }

        public void SearchPredmet()
        {
            if (SelectedItem == null && Filter == "")
            {
                MessageBox.Show("Izaberite tip pretrage i unesite zeljenu rec");
            }
            else if (SelectedItem == null)
            {
                MessageBox.Show("Izaberite tip pretrage");
            }
            else if (Filter == "")
            {
                MessageBox.Show("Unesite rec za filtriranje");
            }
            else if (SelectedItem != null && Filter != "")
            {
                ObservableCollection<Predmet> filteredStudents = new ObservableCollection<Predmet>();
                switch (SelectedItem)
                {
                    case "naziv":
                        filteredStudents = new ObservableCollection<Predmet>(Predmeti.Where(item => item.Naziv.Contains(Filter)));
                        break;
                    case "katedra":
                        filteredStudents = new ObservableCollection<Predmet>(Predmeti.Where(item => item.Katedra.Contains(Filter)));
                        break;
                    case "profesor":
                        filteredStudents = new ObservableCollection<Predmet>(Predmeti.Where(item => item.Profesor.Contains(Filter)));
                        break;
                }
                Predmeti.Clear();
                filteredStudents.ToList().ForEach(item => Predmeti.Add(item));
            }
            
        }

        public void CancelSearch()
        {
            Predmeti.Clear();
            try
            {
                this.service.getPredmeti().ForEach(item => Predmeti.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void SecondWindowClosed(object sender, EventArgs e)
        {
            Predmeti.Clear();
            try
            {
                this.service.getPredmeti().ForEach(item => Predmeti.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
