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

namespace WpfApp.ViewModels
{
    public class RegistrationExamViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Ispit> Ispiti { get; set; }
        public ObservableCollection<Predmet> Predmeti { get; set; }
        public ObservableCollection<Predmet> FiltriraniPredmeti { get; set; }

        private Student student { get; set; }
        private readonly IService service;
        public ICommand AddCommand { get; }

        private Model.Ispit ispit = new Model.Ispit();
        public string Ime
        {
            get { return ispit.Ime; ; }
            set
            {
                ispit.Ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }

        public string Prezime
        {
            get { return ispit.Prezime; }
            set
            {
                ispit.Prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }

        public string Predmet
        {
            get { return ispit.Predmet; }
            set
            {
                ispit.Predmet = value;
                OnPropertyChanged(nameof(Predmet));
            }
        }

        public string Profesor
        {
            get { return ispit.Profesor; }
            set
            {
                ispit.Profesor = value;
                OnPropertyChanged(nameof(Profesor));
            }
        }

        public DateTime Vreme
        {
            get { return ispit.Vreme; }
            set
            {
                ispit.Vreme = value;
                OnPropertyChanged(nameof(Vreme));
            }
        }

        private Predmet _selectedItem;
        public Predmet SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                // Perform any additional logic or actions based on the selected item
                UpdateTextBoxValue();
                OnPropertyChanged(nameof(SelectedItem)); // Notify property changed
            }
        }

        public void UpdateTextBoxValue()
        {
            if (SelectedItem != null)
            {
                // Update the TextBox value based on the selected item
                Vreme = DateTime.Now;
                Profesor = SelectedItem.Profesor;// Replace SomeProperty with the actual property of the selected item you want to display
            }
            else
            {
                Profesor = string.Empty; // Clear the TextBox if no item is selected
            }
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public RegistrationExamViewModel(IService service,Student student)
        {
            this.student = student;
            this.service = service;
            
            Ime = this.student.Ime;
            Prezime = this.student.Prezime;

            Ispiti = new ObservableCollection<Ispit>();
            service.getIspitiByIdStudent(this.student.Id).ForEach(item => Ispiti.Add(item));

            Predmeti = new ObservableCollection<Predmet>();
            this.service.getPredmeti().ToList().ForEach(item => Predmeti.Add(item));

            FiltriraniPredmeti = new ObservableCollection<Predmet>(Predmeti.Where(predmet => !Ispiti.Any(ispit => ispit.IdPredmet == predmet.Id)));
            if(FiltriraniPredmeti == null)
            {
                MessageBox.Show("Prijavili ste ispite za postojece predmete!");
            }
            AddCommand = new RelayCommand(AddIspit);
        }


        public void AddIspit()
        {

            if (!IsFormValid())
            {
                MessageBox.Show("Niste izabrali predmet!");
            }
            else
            {
                var ispit = new Ispit
                {
                    IdStudent = student.Id,
                    Vreme = Vreme,
                    IdPredmet = SelectedItem.Id,
                    Student = student,
                    Predmet = SelectedItem

                };

                service.insertIspit(ispit);
                Ime = string.Empty;
                Prezime = string.Empty;
                Profesor = string.Empty; ;


                Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                window?.Close();
            }

        }

        public bool IsFormValid()
        {
            bool isValid = true;

            // Provjera valjanosti svakog polja forme
            if (string.IsNullOrWhiteSpace(Profesor))
            {
                isValid = false;
            }


            return isValid;
        }


    }
}
