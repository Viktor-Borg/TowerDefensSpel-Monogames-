using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.MapGeneration
{
    class Map
    {
        private Tile[] tiles;
        private PathPoint[] pathPoints;

        public Map(Tile[] tiles, PathPoint[] pathPoints)
        {
            this.tiles = tiles; 
            this.pathPoints = pathPoints;
        }

        public void DrawMap(SpriteBatch spriteBatch, Texture2D[] textures)
        {
            
            foreach(Tile tile in tiles)
            {
                if(tile.Type == Type.grass)
                {
                    spriteBatch.Draw(textures[0], new Vector2(tile.X, tile.Y), Color.White);
                }
                else if(tile.Type == Type.water)
                {
                    spriteBatch.Draw(textures[1], new Vector2(tile.X, tile.Y), Color.White);
                }
                else if(tile.Type == Type.road)
                {
                    spriteBatch.Draw(textures[2], new Vector2(tile.X, tile.Y), Color.White);
                }
            }
           
        }

        //public TileSet TileSet { get { return backgroundTiles; } }
        public PathPoint[]   PathPoints { get { return pathPoints; } }
        public Tile[]        MapTiles { get { return tiles; } }
        
    }
}
