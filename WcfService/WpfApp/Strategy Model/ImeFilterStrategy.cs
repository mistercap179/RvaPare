using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Strategy_Model
{
    public class ImeFilterStrategy : IFilterStrategy<Student>
    {
        public IEnumerable<Student> Filter(IEnumerable<Student> collection, string filter)
        {
            return collection.Where(item => item.Ime.Contains(filter));
        }
    }
}
