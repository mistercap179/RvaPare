using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    [DataContract]
    public class Predmet
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public string Katedra { get; set; }
        [DataMember]
        public string Profesor { get; set; }/*
        [DataMember]
        public ICollection<Ispit> Ispiti { get; set; }*/

        public Predmet(int id,string naziv,string katedra,string profesor)
           /* , ICollection<Ispit> ispiti)*/
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Katedra = katedra;
            this.Profesor = profesor;
            /*this.Ispiti = ispiti;*/
        }

        public Predmet() { }


    }
}
