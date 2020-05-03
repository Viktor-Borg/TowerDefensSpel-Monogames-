using Microsoft.Xna.Framework;
using TowerDefenseSpel.MapGeneration;
using System;

namespace TowerDefenseSpel
{
    /// <summary>
    /// used for guidance for the enemies path.
    /// </summary>
    class PathPoint : Tile
    {
        private float x;
        private float y;

        //takes in the position of the pathpoint and calls the tile constructor and specefies that this is a tile of type pathpoint.
        public PathPoint(float x, float y) : base(1, MapGeneration.Type.pathPoint, new Vector2(x, y))
        {
            this.x = x;
            this.y = y;
        }
        
    }
}
