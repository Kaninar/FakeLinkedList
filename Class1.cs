using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_LAB
{
    public class Item<T>
    {
        public T Num { get; set; }
        public Item(T num)
        {
            this.Num = num;
        }
    }
}
