using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class SortByDuration : IComparer<Trial>
    {
        public int Compare(Trial trial1, Trial trial2)
        {
            if (trial1.Duration < trial2.Duration) return -1;
            if (trial1.Duration == trial2.Duration) return 0;
            return 1;
        } 
    }
}
