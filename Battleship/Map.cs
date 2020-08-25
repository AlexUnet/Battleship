using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Map
    {
        #region Variables

        private Box[,] mapP1 = new Box[Init.TAM, Init.TAM];
        private Box[,] mapP2 = new Box[Init.TAM, Init.TAM];
        private List<int> positionBuffer = new List<int>();

        #endregion

        #region Constructor

        public Map()
        {

        }

        #endregion

        #region Inicialize

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
        #endregion

        #region Actions

        public void SetUnit(string unitType, int dir, int i,int j, bool owner)
        {
            int size = 0;
            int value = 0;
            
            Box[,] map = null;

            SetOwner(owner, ref map);

            SetUnitType(unitType, ref size, ref value);

            CheckPath(dir, i, j,size,map);

            PlaceUnit(value, map);
            

        }
        public void PlaceUnit(int value, Box[,] map)
        {
            try
            {
                for (int i = 0; i < positionBuffer.Count; i++)
                {
                    int a = positionBuffer[i];
                    int b = positionBuffer[i + 1];
                    PlaceUnit(a, b, map,value);
                }
            }catch(Exception e) { Debug.WriteLine("SE INTENTÓ ACCEDER A UNA POSICIÓN FUERA DEL TAMAÑO DEL ARREGLO"); }
            
        }
        public void SetOwner(bool a, ref Box[,]b)
        {
            if (a)
                b = mapP1;
            else
                b = mapP2;            
        }
        public bool CheckPath(int dir,int i, int j,int size,Box[,] map)
        {
            if (size == 0)
                return true;

            switch (dir)
            {
                case 1: //up
                    if (CheckPosition(i, j, map))
                        CheckPath(dir, i - 1, j, size - 1, map);
                    break;
                case -1://down
                    if (CheckPosition(i, j, map))
                        CheckPath(dir, i + 1, j, size - 1, map);
                    break;
                case 2://right
                    if (CheckPosition(i, j, map))
                        CheckPath(dir, i, j + 1, size - 1, map);
                    break;
                case -2://left
                    if (CheckPosition(i, j, map))
                        CheckPath(dir, i - 1, j, size - 1, map);
                    break;
                default:
                    break;
            }
            return false;
        }
        public bool CheckPosition(int i, int j, Box[,] map)
        {
            try
            {
                if (map[i, j] != null)
                    if (map[i, j].GetValue() == 0)
                    {
                        positionBuffer.Add(i);
                        positionBuffer.Add(j);
                        return true;
                    }
                    else
                        positionBuffer.Clear();
            }catch(Exception e){ Debug.WriteLine("SE INTENTÓ ACCEDER A UN PUNTO FUERA DE LOS LIMITES"); }

            return false;
        }
        public void SetUnitType(string unitName, ref int size , ref int value )
        {
            switch (unitName)
            {
                case "Boat"://1
                    size = 2;
                    value = 1;
                    break;
                case "Armored Boat"://2
                    size = 4;
                    value = 2;
                    break;
                case "SubMarine"://3
                    size = 4;
                    value = 3;
                    break;
                case "Aircraft carry"://4
                    size = 5;
                    value = 4;
                    break;
                default:
                    break;
            }
        }

        public void PlaceUnit(int i, int j, Box[,] a, int value)
        {
            a[i, j].SetValue(value);
        }

        #endregion

        #region SpecialFunctions
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
        #endregion

    }
}
