using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Strategy_Model
{
    public interface IFilterStrategy<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> collection, string filter);
    }
}
