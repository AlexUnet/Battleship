using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Box
    {
        private int value;
        private bool taked;

        public Box()
        {
            value = 0;
            taked = false;
        }

        public bool GetTaked()
        {
            return taked;
        }
        public int GetValue()
        {
            return value;
        }

        override
        public String ToString()
        {
            return value.ToString();
        }

    }
}
