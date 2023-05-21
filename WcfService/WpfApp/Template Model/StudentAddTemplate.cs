using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Template_Model
{
    abstract class StudentAddTemplate
    {
        public void AddStudent()
        {
            if (ValidateForm())
            {
                if (CheckExistingStudent())
                {
                    DisplayErrorMessage("Student vec postoji!");
                }
                else
                {
                    InsertStudent();
                    DisplaySuccessMessage("Student je uspesno dodat!");
                }
            }
            else
            {
                DisplayErrorMessage("Niste popunili sva polja forme!");
            }
        }

        protected abstract bool ValidateForm();
        protected abstract bool CheckExistingStudent();
        protected abstract void InsertStudent();
        protected abstract void DisplayErrorMessage(string message);
        protected abstract void DisplaySuccessMessage(string message);
    }
}
