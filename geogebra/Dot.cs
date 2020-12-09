using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geogebra
{
    public class Dot
    {
        public int getNearest(List<int> p_list, int p)
        {
            int l = 0, r = p_list.Count() - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (p_list[mid] <= p_list[l])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return l;
        }
    }
}
