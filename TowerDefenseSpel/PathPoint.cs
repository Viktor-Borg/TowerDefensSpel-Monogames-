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
        private float x;
        private float y;

        public PathPoint(float x, float y) : base(1, MapGeneration.Type.pathPoint, new Vector2(x, y))
        {
            this.x = x;
            this.y = y;
        }
        
    }
}
