using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.MapGeneration
{
    enum Type { standard,grass,water,road,powerPoint,pathPoint}
    /// <summary>
    /// represents the tiles used ingame.
    /// </summary>
    class Tile:Gameobject
    {
        private int       size;
        private Type      type;

        //sets the size,type and position of this instance.
        public Tile(int size, Type type, Vector2 position) : base((int)position.X, (int)position.Y)
        {
            this.size    = size;
            this.type    = type;
        }


        #region Attributes

        public Type Type { get { return type; } }
        public int Size { get { return size; } }

        #endregion




    }
}
