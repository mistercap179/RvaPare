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
        private int id;
        private DateTime vreme;
        private int idPredmet;
        private int idStudent;
        private Student student;
        private Predmet predmet;
        private short polozen;


        [DataMember]
        public int Id { get => id; set=> id = value; }
        [DataMember]
        public DateTime Vreme { get => vreme; set => vreme = value; }
        [DataMember]
        public int IdPredmet { get => idPredmet; set => idPredmet = value; }
        [DataMember]
        public int IdStudent { get => idStudent; set => idStudent = value; }
        [DataMember]
        public Student Student { get => student; set => student = value; }
        [DataMember]
        public Predmet Predmet { get => predmet; set => predmet = value; }
        [DataMember]
        public short Polozen { get => polozen; set => polozen = value; }

        public Ispit(int id,DateTime vreme,int idPredmet,int idStudent,Student student, Predmet predmet,short polozen)
        {
            this.Id = id;
            this.IdPredmet = idPredmet;
            this.IdStudent = idStudent;
            this.Student = student;
            this.Predmet = predmet;
            this.Vreme = vreme;
            this.Polozen = polozen;
        }

        public Ispit() { }


    }
}
