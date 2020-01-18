using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.MapGeneration
{
    class Map
    {
        private Tile[] tiles;
        private PathPoint[] pathPoints;

        public Map(Tile[] tiles, PathPoint[] pathPoints)
        {
            this.tiles = tiles; 
            this.pathPoints = pathPoints;
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            
            /*foreach(Tile tile in backgroundTiles)
            {

            }*/
           
        }

        //public TileSet TileSet { get { return backgroundTiles; } }
        public PathPoint[]   PathPoints { get { return pathPoints; } }
        public Tile[]        MapTiles { get { return tiles; } }
        
    }
}
