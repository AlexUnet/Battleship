using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Map
    {
        public Map()
        {

        }

        public Box[,] mapP1 = new Box[Init.TAM, Init.TAM];
        public Box[,] mapP2 = new Box[Init.TAM, Init.TAM];

        public void InicializeMap()
        {
            for (int i = 0; i < Init.TAM; i++)
            {
                for (int j = 0; j < Init.TAM; j++)
                {
                    mapP1[i, j] = new Box();
                    mapP2[i, j] = new Box();
                }
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < Init.TAM; i++)
            {
                for (int j = 0; j < Init.TAM; j++)
                {
                    Debug.Write("|" + mapP1[i, j].ToString() + "|");
                }
                Debug.WriteLine("");
            }

            Debug.WriteLine("------------------------------------------------");

            for (int i = 0; i < Init.TAM; i++)
            {
                for (int j = 0; j < Init.TAM; j++)
                {
                    Debug.Write("|" + mapP2[i, j].ToString() + "|");
                }
                Debug.WriteLine("");
            }
        }


    }
}
