using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DBCrud
{
    public class DBCrud : IDBCrud
    {
        Conversion.Conversion conversion = new Conversion.Conversion();

        #region upis
        public void insertPredmet(Predmet predmet)
        {

            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Predmets.Add(predmet);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void insertStudent(Student student)
        {
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void insertIspit(Ispit ispit)
        {
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Ispits.Add(ispit);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region citanje
        public List<Models.Student> getStudenti()
        {
            List<Models.Student> studenti = new List<Models.Student>();
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Students.ToList().ForEach(s => studenti.Add(conversion.conversionStudent(s)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return studenti;
        }

        public List<Models.Predmet> getPredmeti()
        {
            List<Models.Predmet> predmeti = new List<Models.Predmet>();
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Predmets.ToList().ForEach(p => predmeti.Add(conversion.conversionPredmet(p)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return predmeti;
        }

        public List<Models.Ispit> getIspiti()
        {
            List<Models.Ispit> ispiti = new List<Models.Ispit>();
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Ispits.ToList().ForEach(i => ispiti.Add(conversion.conversionIspit(i)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ispiti;
        }

        public List<Models.Ispit> getIspitiById(int idStudent)
        {
            List<Models.Ispit> ispiti = new List<Models.Ispit>();
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Ispits.Where(x => x.idStudent == idStudent).ToList()
                        .ForEach(i => ispiti.Add(conversion.conversionIspit(i)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ispiti;
        }

        public bool checkStudent(Student student)
        {
            bool exist = false;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    exist = db.Students.Any(x => x.ime == student.ime &&
                                    x.prezime == student.prezime &&
                                    x.brojIndexa == student.brojIndexa);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return exist;
        }




        public bool checkPredmet(Predmet predmet)
        {
            bool exist = false;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    exist = db.Predmets.Any(x => x.naziv == predmet.naziv &&
                                    x.katedra == predmet.katedra &&
                                    x.profesor == predmet.profesor);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return exist;
        }



        #endregion

        #region brisanje

        public int deleteStudent(int id)
        {
            int ret = -1;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Students.ToList().ForEach((x) => {
                        if (x.id == id)
                        {
                            db.Students.Remove(x);
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        public int deletePredmet(int id)
        {
            int ret = -1;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Predmets.ToList().ForEach((x) => {
                        if (x.id == id)
                        {
                            db.Predmets.Remove(x);
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }




        #endregion

        #region modifikacija
        public int modifyStudent(Models.Student student)
        {
            int ret = -1;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Students.ToList().ForEach((x) => {
                        if (x.id == student.Id)
                        {
                            x.ime = student.Ime;
                            x.prezime = student.Prezime;
                            x.smer = student.Smer;
                            x.brojIndexa = student.BrojIndexa;
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int modifyPredmet(Models.Predmet predmet)
        {
            int ret = -1;
            try
            {
                using (var db = new StudentskaSluzbaEntities())
                {
                    db.Predmets.ToList().ForEach((x) => {
                        if (x.id == predmet.Id)
                        {
                            x.katedra = predmet.Katedra;
                            x.naziv = predmet.Naziv;
                            x.profesor = predmet.Profesor;
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        #endregion

    }
}
