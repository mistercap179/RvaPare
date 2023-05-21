using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Template_Model
{
    class StudentAddTemplateImplementation : StudentAddTemplate
    {
        private Student student = new Student(); 
        private readonly IService service;
        public StudentAddTemplateImplementation(Student student,IService service)
        {
            this.service = service;
            this.student = student;
        }

        protected override bool ValidateForm()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(student.Ime) || string.IsNullOrWhiteSpace(student.Prezime)
                || string.IsNullOrWhiteSpace(student.Smer) || string.IsNullOrWhiteSpace(student.BrojIndexa))
            {
                isValid = false;
            }
            return isValid;
        }

        protected override bool CheckExistingStudent()
        {
            return this.service.checkStudent(student);
        }

        protected override void InsertStudent()
        {
            this.service.insertStudent(student);
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }

        protected override void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        protected override void DisplaySuccessMessage(string message)
        {
            MessageBox.Show(message);
        }

    }
}
