
namespace TowerDefenseSpel
{
    /// <summary>
    /// base class for all objects in the game.
    /// </summary>
    class Gameobject
    {
        protected int x;
        protected int y;

        public Gameobject(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        #region Attributes

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        #endregion


    }
}
