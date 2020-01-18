using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TowerDefenseSpel.MapGeneration;

namespace TowerDefenseSpel
{
    class PathPoint : Tile
    {
        private int x;
        private int y;

        public PathPoint(int x, int y) : base(1, MapGeneration.Type.pathPoint, new Vector2(x, y))
        {
            this.x = x;
            this.y = y;
        }
        
    }
}
