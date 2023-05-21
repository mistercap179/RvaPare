using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
   /* [ServiceBehavior]*/
    public class Service : IService
    {
        DBCrud.IDBCrud crud = new DBCrud.DBCrud();

        public Service(DBCrud.IDBCrud crud)
        {
            this.crud = crud;
        }

        public void insertStudent(Models.Student student)
        {

            crud.insertStudent(
                new Student()
                {
                    id = student.BrojIndexa,
                    ime = student.Ime,
                    prezime = student.Prezime,
                    smer = student.Smer
                }
            );
        }

        public void insertPredmet()
        {
            throw new NotImplementedException();
        }

    }
}
