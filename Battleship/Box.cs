using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Box
    {
        #region Variables

        private int value;
        private bool taked;

        #endregion

        #region Constructor

        public Box()
        {
            value = 0;
            taked = false;
        }

        #endregion

        #region SetsGets
        public void SetTaked(bool taked)
        {
            this.taked = taked;
        }
        public void SetValue(int value)
        {
            this.value = value;
        }

        public bool GetTaked()
        {
            return taked;
        }
        public int GetValue()
        {
            return value;
        }

        #endregion

        #region SpecialFunctions

        override
        public String ToString()
        {
            return value.ToString();
        }

        #endregion

    }
}
