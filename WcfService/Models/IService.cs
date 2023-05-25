using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void insertStudent(Models.Student student);

        [OperationContract]
        void insertPredmet(Models.Predmet predmet);

        [OperationContract]
        void insertIspit(Models.Ispit ispit);

        [OperationContract]
        bool checkStudent(Student student);

        [OperationContract]
        bool checkPredmet(Predmet predmet);

        [OperationContract]
        List<Student> getStudenti();

        [OperationContract]
        List<Predmet> getPredmeti();

        [OperationContract]
        List<Ispit> getIspiti();
        [OperationContract]
        List<Ispit> getIspitiByIdStudent(int id);

        [OperationContract]
        int deleteStudent(int id);

        [OperationContract]
        int deletePredmet(int id);

        [OperationContract]
        int modifyStudent(Models.Student student);

        [OperationContract]
        int modifyPredmet(Models.Predmet predmet);


    }
}
