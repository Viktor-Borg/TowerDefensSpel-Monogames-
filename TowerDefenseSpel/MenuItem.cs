using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel
{
    /// <summary>
    /// used as elements in the menu class.
    /// </summary>
    class MenuItem : VisibleGameobject
    {
        private Texture2D texture;
        private Vector2   position;
        private byte      currentState;

        //takes in the texture , position and state which this menuitem represents.
        public MenuItem(Texture2D texture, Vector2 position, byte currentState) : base(texture,(int)position.X,(int)position.Y)
        {
            this.texture      = texture;
            this.position     = position;
            this.currentState = currentState;
        }

        #region Attributes

        public Texture2D Texture { get { return texture; } }
        public Vector2 Position { get { return position; } }
        public byte State { get { return currentState; } }

        #endregion

    }
}
