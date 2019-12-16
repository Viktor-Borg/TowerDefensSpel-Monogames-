using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseSpel.MapGeneration
{
    static class UIMapReader
    {
        static Texture2D[] iconTextures;
        static SpriteBatch draw;
        static GameWindow window;
        static ContentManager content;

        public static void UiMapReaderinitializer(SpriteBatch spriteBatch, GameWindow gameWindow, ContentManager contentManager)
        {
            draw = spriteBatch;
            window = gameWindow;
            content = contentManager;

        }

        static void LoadIcons()
        {
            iconTextures = new Texture2D[3];
            iconTextures[0] = content.Load<Texture2D>("grass");
            DrawIcons();
         
            
        }

        public static void DrawIcons()
        {
            draw.Begin();
            int extraDistance = 15;
            for (int i = 0; i < iconTextures.Length; i++)
            {
                draw.Draw(iconTextures[i], new Vector2(extraDistance, window.ClientBounds.Width), Color.White);
                extraDistance += iconTextures[i].Width;
            }
            draw.End();
        }

        public static void Drawtiles()
        {

        }

        public static void DrawPowersources()
        {

        }

        

    }
}
