using System;
using System.Collections.Generic;
using System.Collections;

namespace TowerDefenseSpel
{
    class BitArray2D
    {
        int x;
        int y;
        Dictionary<int,BitArray> bitArray2d = new Dictionary<int, BitArray>();

        public BitArray2D(int x, int y)
        {
            this.x = x;
            this.y = y;
            for(int i = 0; i<y; i++)
            {
                bitArray2d.Add(i, new BitArray(x));
            }
        }

        public bool GetValue(int x, int y)
        {
            BitArray temp = bitArray2d[y];
            return temp[x];
        }

        public void SetValue(bool value, int x, int y)
        {
            BitArray temp = bitArray2d[y];
            temp[x] = value;
        }


    }
}
