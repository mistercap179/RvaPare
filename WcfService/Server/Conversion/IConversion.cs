using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Conversion
{
    public interface IConversion
    {
        Models.Student conversionStudent(Student student);
        Models.Ispit conversionIspit(Ispit ispit);
        Models.Predmet conversionPredmet(Predmet predmet);

    }
}
