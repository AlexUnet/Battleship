using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Init
    {
        public static int TAM = 7;
        private Map map = new Map();
        public Init()
        {

        }

        public void StartProgram()
        {
            
            map.InicializeMap();
            map.PrintMap();
            map.SetUnit("Armored Boat", -1, 0, 5, false);
            map.PrintMap();
            GetPlacement();
            map.PrintMap();
        }
        public void GetOrder()
        {

        }

        public void GetPlacement()
        {
            string tipo;
            int dir;
            int t = 5;
            int i; int j;
            while (t > 0)
            {
                try
                {
                    Console.WriteLine("Ingrese la coordenada para su barquito " + t);
                    i = Int32.Parse(Console.ReadLine());
                    j = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el tipo de barco " + t);
                    tipo = Console.ReadLine();
                    Console.WriteLine("Ingrese la dirección del barco " + t);
                    dir = Int32.Parse(Console.ReadLine());

                    if(map.SetUnit(tipo, dir, i, j, true))
                    {
                        map.PrintMap();
                        t--;
                    }                    
                }
                catch(Exception e) { Console.WriteLine("NO ES UNA ENTRADA NUMERICA VALIDA"); t++; }
                
            }
        }

        #region SpecialFunctions

        public static int randomN(int min,int max)
        {
            return new Random().Next(min, max);
        }

        #endregion
    }
}
