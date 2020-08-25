using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Init
    {
        public static int TAM = 7;
        public Init()
        {

        }

        public void StartProgram()
        {
            Map map = new Map();
            map.InicializeMap();
            map.PrintMap();
        }
    }
}
