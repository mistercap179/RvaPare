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
using WpfApp.Template_Model;

namespace WpfApp.ViewModels
{
    public class AddStudentViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IService service;
        public ICommand AddCommand { get; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddStudentViewModel(Models.IService service)
        {

            this.service = service;
            AddCommand = new RelayCommand(AddStudent);

        }

        public void AddStudent()
        {

            var student = new Student
            {
                Ime = Ime,
                Prezime = Prezime,
                BrojIndexa = BrojIndexa,
                Smer = Smer
            };

            StudentAddTemplate studentAddTemplate = new StudentAddTemplateImplementation(student,this.service);
            studentAddTemplate.AddStudent();
        }


    }
}
