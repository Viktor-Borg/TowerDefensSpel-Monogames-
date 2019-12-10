﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseSpel.MapGeneration
{
    class TileSet
    {
        List<Tile> tiles = new List<Tile>();
        Tile[,] tilePLacement;

        private int platserX;
        private int platserY;

        public TileSet(Vector2 windowSize, Vector2 tileSize, ContentManager content,Texture2D texture)
        {
            platserX = (int)windowSize.X / (int)tileSize.X;
            platserY = (int)windowSize.Y / (int)tileSize.Y;
            tilePLacement = new Tile[platserX+1, platserY+1];

            for(int i = 0; i<platserY; i++)
            {
                for(int j = 0; j<platserX; j++)
                {
                    tilePLacement[i, j] = new Tile(texture);
                }
            }
        }

        private void foo(int x, int y)
        {

        }

        public Tile[,] Tiles { get { return tilePLacement;} }
        public int PlatserX { get { return platserX; } }
        public int PlatserY { get { return platserY; } }
    }
}
