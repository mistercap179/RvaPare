using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Prijava
    {
        public int Id { get; set; }
        public DateTime Vreme { get; set; }
        public int IdPredmet { get; set; }
        public int IdStudent { get; set; }
        public Models.Student Student { get; set; }
        public Models.Predmet Predmet { get; set; }
        public string Polozen { get; set; }
    }
}
