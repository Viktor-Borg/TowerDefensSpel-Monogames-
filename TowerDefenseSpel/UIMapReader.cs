using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.MapGeneration
{
    static class UIMapReader
    {
        static private Texture2D[]                    iconTextures;
        static private SpriteBatch                    draw;
        static private GameWindow                     window;
        static private ContentManager                 content;
        static private Dictionary<Texture2D, Vector2> icons = new Dictionary<Texture2D, Vector2>();

        public static void UiMapReaderinitializer(SpriteBatch spriteBatch, GameWindow gameWindow, ContentManager contentManager)
        {
            draw    = spriteBatch;
            window  = gameWindow;
            content = contentManager;
            LoadIcons();

        }

        static void LoadIcons()
        {
            iconTextures = new Texture2D[3];
            iconTextures[0] = content.Load<Texture2D>("grass");
            iconTextures[1] = content.Load<Texture2D>("water");
            iconTextures[2] = content.Load<Texture2D>("path");
        }

      
        public static void UIMapReaderUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
                if(keyboardState.IsKeyDown(Keys.A))
                {
                    MapCreator.SelectedTexture = iconTextures[0];
                    MapCreator.SelectedType    = Type.grass;
                }
                if(keyboardState.IsKeyDown(Keys.S))
                {
                    MapCreator.SelectedTexture = iconTextures[1];
                    MapCreator.SelectedType    = Type.water;
                }
                if(keyboardState.IsKeyDown(Keys.D))
                {
                    MapCreator.SelectedTexture = iconTextures[2];
                    MapCreator.SelectedType    = Type.road;
                }
            if (keyboardState.IsKeyDown(Keys.F))
            {
                MapCreator.SelectedTexture = null;
                MapCreator.SelectedType = Type.pathPoint;
            }
            
            MapCreator.MapCreatorUpdate();

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                MapCreator.SaveMap();
            }
        }

        public static void Drawtiles(List<Tile> tiles)
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

    }
}
