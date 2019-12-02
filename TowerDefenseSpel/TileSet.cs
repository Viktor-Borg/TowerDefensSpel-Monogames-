using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.MapGeneration
{
    class TileSet
    {
        List<Tile> tiles = new List<Tile>();
        Tile[,] tilePLacement;

        public TileSet(Vector2 windowSize, Vector2 tileSize)
        {
            int platserX = (int)windowSize.X / (int)tileSize.X;
            int platserY = (int)windowSize.Y / (int)tileSize.Y;
            tilePLacement = new Tile[platserX, platserY];

            for(int i = 0; i<platserY; i++)
            {
                for(int j = 0; j<platserX; j++)
                {
                    //tilePLacement[i,j] = new Tile()
                }
            }
        }

        public Tile[,] Tiles { get { return tilePLacement;} }
    }
}
