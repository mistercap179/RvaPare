using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Models;
using WpfApp.Strategy_Model;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private  IService service { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.Student> Students { get; set; }
        public ObservableCollection<string> ListBox { get; set; }
        public Student Student { get; set; }

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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand OpenAddStudentWindowCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ModifyCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }

        public StudentViewModel(IService service)
        {
            this.service = service;
            OpenAddStudentWindowCommand = new RelayCommand(AddStudent);
            DeleteCommand = new RelayCommand<object>(DeleteStudent);
            ModifyCommand = new RelayCommand<object>(ModifyStudent);
            SearchCommand = new RelayCommand(SearchStudent);
            CancelCommand = new RelayCommand(CancelSearch);
            RegistrationCommand = new RelayCommand<object>(RegistrationExam);
            Students = new ObservableCollection<Models.Student>(service.getStudenti());
            ListBox = new ObservableCollection<string>{"ime", "prezime", "index", "smer"};
        }

        private void AddStudent()
        {
            var addStudentViewModel = new AddStudentViewModel(service);
            var secondWindow = new AddStudentWindow() { DataContext = addStudentViewModel };
            secondWindow.Closed += SecondWindowClosed;
            secondWindow.Show();
        }

        private void DeleteStudent(object param)
        {
            if (param is Student item)
            {
                service.deleteStudent(item.Id);
                Students.Remove(item); 
            }
        }
        private void ModifyStudent(object param)
        {
            if (param is Student item)
            {
                var modifyStudentViewModel = new ModifyStudentViewModel(service,item);
                var secondWindow = new ModifyStudent() { DataContext = modifyStudentViewModel };
                
                secondWindow.Closed += SecondWindowClosed;
                secondWindow.Show();
            }

        }

        private void RegistrationExam(object param)
        {
            if (param is Student item)
            {
                var registrationExamViewModel = new RegistrationExamViewModel(service, item);
                var secondWindow = new RegistrationExamView() { DataContext = registrationExamViewModel };
                secondWindow.Closed += RefreshTableIspiti;
                secondWindow.Show();
            }

        }



        public void SearchStudent()
        {
            if(SelectedItem == null && Filter == "")
            {
                MessageBox.Show("Izaberite tip pretrage i unesite zeljenu rec");
            }
            else if (SelectedItem == null)
            {
                MessageBox.Show("Izaberite tip pretrage");
            }
            else if(Filter == "")
            {
                MessageBox.Show("Unesite rec za filtriranje");
            }
            else if(SelectedItem != null && Filter != "")
            {
                ObservableCollection<Student> filteredStudents = new ObservableCollection<Student>();
                IFilterStrategy<Student> filterStrategy = new ImeFilterStrategy();      // default

                switch (SelectedItem)
                {
                    case "ime":
                        filterStrategy = new ImeFilterStrategy();
                        break;
                    case "prezime":
                        filterStrategy = new PrezimeFilterStrategy();
                        break;
                    case "index":
                        filterStrategy = new IndexFilterStrategy();
                        break;
                    case "smer":
                        filterStrategy = new SmerFilterStrategy();
                        break;
                }

                filteredStudents = new ObservableCollection<Student>(filterStrategy.Filter(Students, Filter));
                Students.Clear();
                filteredStudents.ToList().ForEach(item => Students.Add(item));

            }

        }

        public void CancelSearch()
        {
            Students.Clear();
            try
            {
                this.service.getStudenti().ForEach(item => Students.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RefreshTableIspiti(object sender, EventArgs e)
        {
            
            
        }


        private void SecondWindowClosed(object sender, EventArgs e)
        {
            Students.Clear();
            try
            {
                this.service.getStudenti().ForEach(item => Students.Add(item));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
