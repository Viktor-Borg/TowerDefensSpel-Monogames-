using Microsoft.Xna.Framework;
using TowerDefenseSpel.MapGeneration;
using System;

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
