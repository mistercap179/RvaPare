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
    public class ModifyStudentViewModel : INotifyPropertyChanged
    {
        private Student studentTemp = new Student();
        private readonly IService service;
        public ICommand ModifyCommand { get; }

        private Model.Student student = new Model.Student();
        public string Ime
        {
            get { return student.Ime; ; }
            set
            {
                student.Ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }

        public string Prezime
        {
            get { return student.Prezime; }
            set
            {
                student.Prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }

        public string BrojIndexa
        {
            get { return student.BrojIndexa; }
            set
            {
                student.BrojIndexa = value;
                OnPropertyChanged(nameof(BrojIndexa));
            }
        }

        public string Smer
        {
            get { return student.Smer; }
            set
            {
                student.Smer = value;
                OnPropertyChanged(nameof(Smer));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ModifyStudentViewModel(Models.IService service,Student student)
        {
            this.studentTemp = student;

            Ime = student.Ime;
            Prezime = student.Prezime;
            Smer = student.Smer;
            BrojIndexa = student.BrojIndexa;

            this.service = service;
            ModifyCommand = new RelayCommand(ModifyStudent);

        }

        public void ModifyStudent()
        {
            var student = new Student
            {
                Id = this.studentTemp.Id,
                //Ispiti = this.studentTemp.Ispiti,
                Ime = Ime,
                Prezime = Prezime,
                BrojIndexa = BrojIndexa,
                Smer = Smer
            };
            service.modifyStudent(student);

            Ime = string.Empty;
            Prezime = string.Empty;
            Smer = string.Empty; ;
            BrojIndexa = string.Empty; 

            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
