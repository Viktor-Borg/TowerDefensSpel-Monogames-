﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.MapGeneration
{
    class Map
    {
        private TileSet     backgroundTiles;
        private PathPoint[] pathPoints;
        private Powersource[] powersources;

        public Map(TileSet backgroundTiles, PathPoint[] pathPoints,Powersource[] powersources)
        {
            this.backgroundTiles = backgroundTiles;
            this.pathPoints = pathPoints;
            this.powersources = powersources;
        }

        public void DrawMap(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in backgroundTiles.Tiles)
            {

            }
            foreach(Powersource powersource in powersources)
            {

            }
        }

        public TileSet TileSet { get { return backgroundTiles; } }
        public PathPoint[] PathPoints { get { return pathPoints; } }
        public Powersource[] Powersources { get { return powersources; } }
    }
}