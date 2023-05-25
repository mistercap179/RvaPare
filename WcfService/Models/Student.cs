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
        private int id;
        private string brojIndexa;
        private string ime;
        private string prezime;
        private string smer;

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string BrojIndexa { get => brojIndexa; set => brojIndexa = value; }
        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }
        [DataMember]
        public string Smer { get => smer; set => smer = value; }


        public Student(int id,string brojIndexa,string ime,string prezime,string smer)
        {
            this.Id = id;
            this.BrojIndexa = brojIndexa;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Smer = smer;
        }
        public Student() { }

    }
}
