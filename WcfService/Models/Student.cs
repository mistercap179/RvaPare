using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Student
{
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BrojIndexa { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string Smer { get; set; }
        /*[DataMember]
        public ICollection<Ispit> Ispiti { get; set; }*/

        public Student(int id,string brojIndexa,string ime,string prezime,string smer)
/*            ,ICollection<Ispit> ispiti)*/
        {
            this.Id = id;
            this.BrojIndexa = brojIndexa;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Smer = smer;
            /*this.Ispiti = ispiti;*/
        }
        public Student() { }

    }
}
