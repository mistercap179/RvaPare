using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DBCrud
{
    public class DBCrud : IDBCrud
    {

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
    }
}
