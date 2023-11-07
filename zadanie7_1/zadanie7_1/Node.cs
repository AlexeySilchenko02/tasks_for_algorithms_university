using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie7_1
{
    public class Node
    {
        private int value;
        public Node(int value)
        {
            this.value = value;
        }
        public int getValue()
        {
            return this.value;
        }
        public void setValue(int value)
        {
            this.value = value;
        }
    }
}
