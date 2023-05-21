using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DBCrud
{
    public interface IDBCrud
    {
        void insertStudent(Student student);
        void insertPredmet(Predmet predmet);
        void insertIspit(Ispit ispit);

        List<Models.Student> getStudenti();
        List<Models.Predmet> getPredmeti();
        List<Models.Ispit> getIspiti();
        List<Models.Ispit> getIspitiById(int idStudent);

        bool checkStudent(Student student);
        bool checkPredmet(Predmet predmet);

        int deleteStudent(int id);
        int deletePredmet(int id);


        int modifyStudent(Models.Student student);
        int modifyPredmet(Models.Predmet predmet);
    }
}
