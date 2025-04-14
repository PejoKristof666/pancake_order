using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pancake_order
{
    public class pancakes
    {
        public int number { get; set; }
        public string doughtype { get; set; }
        public string fillingtype { get; set; }

        public pancakes(int num, string dough, string filling)
        {
            number = num;
            doughtype = dough;
            fillingtype = filling;
        }
    }

}
