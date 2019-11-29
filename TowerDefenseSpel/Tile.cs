using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel
{
    class Tile
    {
        private Texture2D texture;
        private int       size;
        public Tile(Texture2D texture)
        {
            this.texture = texture;
            this.size = this.texture.Width;
        }

        public Texture2D Texture { get { return texture; } }
        public int Size          { get { return size; } }
    }
}
