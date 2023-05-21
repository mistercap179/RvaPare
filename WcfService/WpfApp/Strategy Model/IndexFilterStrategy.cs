using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Strategy_Model
{
    public class IndexFilterStrategy : IFilterStrategy<Student>
    {
        public IEnumerable<Student> Filter(IEnumerable<Student> collection, string filter)
        {
            return collection.Where(item => item.BrojIndexa.Contains(filter));
        }
    }
}
