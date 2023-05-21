using Models;
using Server.DBCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        Conversion.Conversion conversion = new Conversion.Conversion();
        private IDBCrud _dbCrud { get; set; } = null;

        public Service()
        {
            IUnityContainer container = ServerContainer.Container; 
            this._dbCrud = container.Resolve<IDBCrud>();
        }

        #region dodavanje

        [OperationBehavior]
        public void insertStudent(Models.Student student)
        {

            _dbCrud.insertStudent(new Student()
            {
                ime = student.Ime,
                prezime = student.Prezime,
                smer = student.Smer,
                brojIndexa = student.BrojIndexa
            });
        }

        [OperationBehavior]
        public void insertPredmet(Models.Predmet predmet)
        {
            _dbCrud.insertPredmet(new Predmet()
            {
                katedra = predmet.Katedra,
                profesor = predmet.Profesor,
                naziv = predmet.Naziv
            });
        }

        [OperationBehavior]
        public void insertIspit(Models.Ispit ispit)
        {

            _dbCrud.insertIspit(new Ispit()
            {
                vreme = ispit.Vreme,
                idPredmet = ispit.IdPredmet,
                idStudent = ispit.IdStudent
            });
        }
        #endregion

        #region citanje
        [OperationBehavior]
        public List<Models.Student> getStudenti()
        {
            List<Models.Student> studenti = _dbCrud.getStudenti();
            return studenti;
        }

        [OperationBehavior]
        public List<Models.Predmet> getPredmeti()
        {
            List<Models.Predmet> predmeti = _dbCrud.getPredmeti();
            return predmeti;
        }

        [OperationBehavior]
        public List<Models.Ispit> getIspiti()
        {
            List<Models.Ispit> ispiti = _dbCrud.getIspiti();
            return ispiti;
        }

        [OperationBehavior]
        public List<Models.Ispit> getIspitiByIdStudent(int id)
        {
            List<Models.Ispit> ispiti = _dbCrud.getIspitiById(id);
            return ispiti;
        }


        [OperationBehavior]
        public bool checkStudent(Models.Student student)
        {
            bool exist = _dbCrud.checkStudent(new Student()
            {
                ime = student.Ime,
                prezime = student.Prezime,
                brojIndexa = student.BrojIndexa,
                smer = student.Smer
            });

            return exist;
        }

        [OperationBehavior]
        public bool checkPredmet(Models.Predmet predmet)
        {
            bool exist = _dbCrud.checkPredmet(new Predmet()
            {
                katedra = predmet.Katedra,
                profesor = predmet.Profesor,
                naziv = predmet.Naziv
            });

            return exist;
        }

        #endregion

        #region brisanje

        [OperationBehavior]
        public int deleteStudent(int id)
        {
            return _dbCrud.deleteStudent(id);
        }

        [OperationBehavior]
        public int deletePredmet(int id)
        {
            return _dbCrud.deletePredmet(id);
        }


        #endregion

        #region modifikacija

        [OperationBehavior]
        public int modifyStudent(Models.Student student)
        {
            return _dbCrud.modifyStudent(student);
        }

        [OperationBehavior]
        public int modifyPredmet(Models.Predmet predmet)
        {
            return _dbCrud.modifyPredmet(predmet);
        }
        #endregion
    }
}
