using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TowerDefenseSpel.GamePlay;

namespace TowerDefenseSpel.MapGeneration
{
    /// <summary>
    /// Gets all the tiles and pathpoints which are used in a map and puts them together in one class.
    /// </summary>
    class Map
    {
        private Tile[] tiles;
        private PathPoint[] pathPoints;
        //takes in all the tiles and pathpoints which makes up the map.
        public Map(Tile[] tiles, PathPoint[] pathPoints)
        {
            this.tiles = tiles; 
            this.pathPoints = pathPoints;
        }
        //draws all the tile which makes up the map.
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
        //checks wether or not the user have pressed escape and if they have call all the neccessary reset methods to go back to the main menu.
        public void MapUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                SceneController.CurrentState = SceneController.State.Menu;
                Game1.MapHasBeenSelected = false;
                Game1.HasBeenCalled = false;
                Game1.InteractableMenu.Reset();
                WaveController.Reset();
                TowerController.Reset();
            }
        }

        #region Attributes

        public PathPoint[] PathPoints { get { return pathPoints; } }
        public Tile[] MapTiles { get { return tiles; } }

        #endregion



    }
}
