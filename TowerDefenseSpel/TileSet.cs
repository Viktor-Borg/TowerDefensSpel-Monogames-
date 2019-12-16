using System;
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
        
        Dictionary<string, int[,]> tilePlacement = new Dictionary<string, int[,]>();

        private int platserX;
        private int platserY;
        private Texture2D texture;

        public TileSet(Vector2 windowSize, Vector2 tileSize, ContentManager content,Texture2D[] textures)
        {
            this.platserX = (int)windowSize.X / (int)tileSize.X;
            this.platserY = (int)windowSize.Y / (int)tileSize.Y;
            

            for (int i = 0; i < platserY; i++)
            {
                for (int j = 0; j < platserX; j++)
                {
                    float tempPosition = j * textures[0].Width + (i * textures[0].Height) / (10 * platserY.ToString().Length);
                    string textureId = textures[0].Name;
                    tilePlacement.Add(tempPosition, textureId);
                }
            }

        }

      

       
        public int PlatserX { get { return platserX; } }
        public int PlatserY { get { return platserY; } }
    }
}
