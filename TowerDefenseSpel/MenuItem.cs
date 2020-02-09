using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel
{
    class MenuItem
    {
        private Texture2D texture;
        private Vector2   position;
        private byte      currentState;

        public MenuItem(Texture2D texture, Vector2 position, byte currentState)
        {
            this.texture      = texture;
            this.position     = position;
            this.currentState = currentState;
        }

        public Texture2D Texture { get { return texture; } }
        public Vector2 Position  { get { return position; } }
        public byte State        { get { return currentState;  } }
    }
}
