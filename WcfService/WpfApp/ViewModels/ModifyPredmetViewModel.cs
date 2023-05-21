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
    public class ModifyPredmetViewModel : INotifyPropertyChanged
    {
        private Predmet predmetTemp = new Predmet();

        private readonly IService service;
        public ICommand ModifyCommand { get; }

        private Model.Predmet predmet = new Model.Predmet();

        public string Naziv
        {
            get { return predmet.Naziv; }
            set
            {
                predmet.Naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }

        public string Katedra
        {
            get { return predmet.Katedra; }
            set
            {
                predmet.Katedra = value;
                OnPropertyChanged(nameof(Katedra));
            }
        }

        public string Profesor
        {
            get { return predmet.Profesor; }
            set
            {
                predmet.Profesor = value;
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

        public ModifyPredmetViewModel(Models.IService service, Predmet predmet)
        {
            this.predmetTemp = predmet;

            Naziv = predmet.Naziv;
            Katedra = predmet.Katedra;
            Profesor = predmet.Profesor;

            this.service = service;
            ModifyCommand = new RelayCommand(ModifyPredmet);

        }

        public void ModifyPredmet()
        {
            var predmet = new Predmet
            {
                Id = this.predmetTemp.Id,
                //Ispiti = this.predmetTemp.Ispiti,
                Naziv = Naziv,
                Katedra = Katedra,
                Profesor = Profesor
            };
            service.modifyPredmet(predmet);


            Naziv = string.Empty; 
            Katedra = string.Empty;
            Profesor = string.Empty;

            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
