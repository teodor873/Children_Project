using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Children
{
    public class ChildComparer : IComparer<ChildInfo>
    {
        public int Compare(ChildInfo x, ChildInfo y)
        {
            int result = x.ReturnName().CompareTo(y.ReturnName());
            return result;
        }
    }
}
