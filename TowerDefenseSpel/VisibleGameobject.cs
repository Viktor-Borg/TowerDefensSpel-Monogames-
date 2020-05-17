using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel
{
    /// <summary>
    /// base class for all gameobjects with textures.
    /// </summary>
    class VisibleGameobject : Gameobject
    {
        private Texture2D texture;

        public VisibleGameobject(Texture2D texture, int x,int y) : base(x, y)
        {
            this.texture = texture;
        }

        #region Attributes

        public Texture2D Texture { get { return texture; } set { texture = value; } }

        #endregion


    }
}
