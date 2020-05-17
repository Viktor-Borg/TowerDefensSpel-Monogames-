using System;
using System.Collections.Generic;
using System.Collections;

namespace TowerDefenseSpel
{
    /// <summary>
    /// Works like a twodimensional bool array only it uses bit arrays instead to save memory.
    /// </summary>
    class BitArray2D
    {
        int x;
        int y;
        Dictionary<int,BitArray> bitArray2d = new Dictionary<int, BitArray>();

        //Here it adds bit arrays to a dictionary the dictaonary acts like the y axis in the array.
        public BitArray2D(int x, int y)
        {
            this.x = x;
            this.y = y;
            for(int i = 0; i<y; i++)
            {
                bitArray2d.Add(i, new BitArray(x));
            }
        }

        //get the right array and then find the specified value in said array.
        public bool GetValue(int x, int y)
        {
            BitArray temp = bitArray2d[y];
            return temp[x];
        }

        //works like the get method only it sets a value.
        public void SetValue(bool value, int x, int y)
        {
            BitArray temp = bitArray2d[y];
            temp[x] = value;
        }


    }
}
