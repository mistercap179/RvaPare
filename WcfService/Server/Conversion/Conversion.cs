using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Conversion
{
    public class Conversion : IConversion
    {
        public Models.Student conversionStudent(Student student)
        {    
            return new Models.Student(student.id, student.ime, student.prezime, student.brojIndexa, student.smer);
        }
        public Models.Predmet conversionPredmet(Predmet predmet)
        {
            List<Models.Ispit> ispiti = new List<Models.Ispit>();
            return new Models.Predmet(predmet.id, predmet.naziv, predmet.katedra, predmet.profesor);
        }
        
        public Models.Ispit conversionIspit(Ispit ispit)
        {
            return new Models.Ispit(ispit.id, ispit.vreme, ispit.idPredmet, ispit.idStudent, conversionStudent(ispit.Student), conversionPredmet(ispit.Predmet));
        }




    }
}
