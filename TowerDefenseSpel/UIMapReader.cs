using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.MapGeneration
{
    /// <summary>
    /// responsible for all UI elements when the user creates a new amp.
    /// </summary>
    static class UIMapController 
    {
        static private Texture2D[]                    iconTextures;
        static private SpriteBatch                    draw;
        static private GameWindow                     window;
        static private ContentManager                 content;
        static private Dictionary<Texture2D, Vector2> icons = new Dictionary<Texture2D, Vector2>();
        static private bool                           isSaved = false;
        //initilize the class.
        static public void UiMapReaderinitializer(SpriteBatch spriteBatch, GameWindow gameWindow, ContentManager contentManager)
        {
            draw    = spriteBatch;
            window  = gameWindow;
            content = contentManager;
            LoadIcons();

        }
        //loads all the tile textures.
        static private void LoadIcons()
        {
            iconTextures = new Texture2D[3];
            iconTextures[0] = content.Load<Texture2D>("grass");
            iconTextures[1] = content.Load<Texture2D>("water");
            iconTextures[2] = content.Load<Texture2D>("path");
        }

      //responsible for checking if the user chnages the tile type they are using as well as if they are pressing escape and calls all the necessary reset methods for the user to go back to the main menu. Also checks if the user presses eneter and calls the save map function.
        static public void UIMapReaderUpdate(GameTime gamtime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if(keyboardState.IsKeyDown(Keys.A))
            {
                MapController.SelectedTexture = iconTextures[0];
                MapController.SelectedType    = Type.grass;
            }
            if(keyboardState.IsKeyDown(Keys.S))
            {
                MapController.SelectedTexture = iconTextures[1];
                MapController.SelectedType    = Type.water;
            }
            if(keyboardState.IsKeyDown(Keys.D))
            {
                MapController.SelectedTexture = iconTextures[2];
                MapController.SelectedType    = Type.road;
            }
            if (keyboardState.IsKeyDown(Keys.F))
            {
                MapController.SelectedType = Type.pathPoint;
            }
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                SceneController.CurrentState = SceneController.State.Menu;
                Game1.NameChosen = false;
                InptController.MapName = "";
                InptController.IsNameDone = false;
                Game1.HelpMenuActive = true;
            }
            
            MapController.MapCreatorUpdate(gamtime);

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                if (!isSaved)
                {
                    MapController.SaveMap();
                    isSaved = true;
                }
               
            }
        }
        //draws all the tiles while the user is creating a new map.
        static public void Drawtiles(List<Tile> tiles)
        {
            foreach(Tile tile in tiles)
            {
                if(tile.Type == Type.grass)
                {
                    draw.Draw(iconTextures[0], new Vector2(tile.X, tile.Y), Color.White);
                }
                else if(tile.Type == Type.road)
                {
                    draw.Draw(iconTextures[2], new Vector2(tile.X, tile.Y), Color.White);
                }
                else if(tile.Type == Type.water)
                {
                    draw.Draw(iconTextures[1], new Vector2(tile.X, tile.Y), Color.White);
                }
                
            }

        }

        #region Attributes

        public static Texture2D GrassTexture { get { return iconTextures[0]; } }

        #endregion

    }
}
