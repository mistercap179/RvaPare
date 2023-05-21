using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class AddPredmetViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IService service;
        public ICommand AddCommand { get; }

        private string _naziv;
        public string Naziv
        {
            get { return _naziv; }
            set
            {
                _naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }

        private string _katedra;
        public string Katedra
        {
            get { return _katedra; }
            set
            {
                _katedra = value;
                OnPropertyChanged(nameof(Katedra));
            }
        }

        private string _profesor;
        public string Profesor
        {
            get { return _profesor; }
            set
            {
                _profesor = value;
                OnPropertyChanged(nameof(Profesor));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsFormValid()
        {
            bool isValid = true;

            // Provjera valjanosti svakog polja forme
            if (string.IsNullOrWhiteSpace(Naziv) || string.IsNullOrWhiteSpace(Katedra)
                || string.IsNullOrWhiteSpace(Profesor))
            {
                isValid = false;
            }


            return isValid;
        }



        public AddPredmetViewModel(Models.IService service)
        {

            this.service = service;
            AddCommand = new RelayCommand(AddPredmet);

        }

        public void AddPredmet()
        {
            var predmet = new Predmet
            {
                Naziv = Naziv,
                Katedra = Katedra,
                Profesor = Profesor
            };

            if (!IsFormValid())
            {
                MessageBox.Show("Niste popunili sva polja forme!");
            }
            else
            {

                if (this.service.checkPredmet(predmet))
                {
                    MessageBox.Show("Predmet već postoji.");
                }
                else
                {
                    insertPredmet(predmet);
                }
            }
        }

        public void insertPredmet(Predmet predmet)
        {
            this.service.insertPredmet(predmet);
            resfreshForm();
        }

        public void resfreshForm()
        {
            Naziv = string.Empty;
            Katedra = string.Empty;
            Profesor = string.Empty;

            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
