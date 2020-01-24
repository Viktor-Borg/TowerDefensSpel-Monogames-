using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel
{
    class VisibleGameobject : Gameobject
    {
        private Texture2D texture;

        public VisibleGameobject(Texture2D texture, int x,int y) : base(x, y)
        {
            this.texture = texture;
        }

        public Texture2D Texture { get { return texture; } set { texture = value; } }
            
    }
}
