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
        private int id;
        private string naziv;
        private string katedra;
        private string profesor;

        [DataMember]
        public int Id { get => id; set => id = value; }
        [DataMember]
        public string Naziv { get => naziv; set => naziv = value; }
        [DataMember]
        public string Katedra { get => katedra; set => katedra = value; }
        [DataMember]
        public string Profesor { get => profesor; set => profesor = value; }

        public Predmet(int id,string naziv,string katedra,string profesor)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Katedra = katedra;
            this.Profesor = profesor;
        }

        public Predmet() { }


    }
}
