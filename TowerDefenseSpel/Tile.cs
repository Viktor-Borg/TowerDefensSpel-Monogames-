using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.MapGeneration
{
    enum Type { standard,grass,water,road,powerPoint,pathPoint}
    class Tile:Gameobject
    {
        private int       size;
        private Type      type;

        public Tile(int size, Type type, Vector2 position) : base((int)position.X, (int)position.Y)
        {
            this.size    = size;
            this.type    = type;
        }

        public Type      Type { get { return type; } }
        public int       Size { get { return size; } }
        
        
      
    }
}
