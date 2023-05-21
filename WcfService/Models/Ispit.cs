using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Ispit
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Vreme { get; set; }
        [DataMember]
        public int IdPredmet { get; set; }
        [DataMember]
        public int IdStudent { get; set; }
        [DataMember]
        public Student Student { get; set; }
        [DataMember]
        public Predmet Predmet { get; set; }

        public Ispit(int id,DateTime vreme,int idPredmet,int idStudent,Student student, Predmet predmet)
        {
            this.Id = id;
            this.IdPredmet = idPredmet;
            this.IdStudent = idStudent;
            this.Student = student;
            this.Predmet = predmet;
            this.Vreme = vreme;
        }

        public Ispit() { }


    }
}
