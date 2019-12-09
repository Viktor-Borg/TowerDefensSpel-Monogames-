﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseSpel.MapGeneration;

namespace TowerDefenseSpel
{
    static class SceneManager
    {
        private static Texture2D menuSprite;
        private static Vector2 menuPos;
        private static Menu menu;
        private static PrintText printText;

        public enum State : byte{Menu, LevelPicker, HighScore, Quit,MapGeneration, Game };

        private static State currentState;

        public static void Initialize()
        {

        }

        public static void LoadContent(ContentManager content, GameWindow window)
        {
            byte[] states = new byte[3];
            for(int i = 0; i< states.Length; i++)
            {
                states[i] = (byte)(i + 1);
            }

            menu = XmlReader.LoadMenuScene("Mapdata.xml", states, content, 0);

           // XmlReader.TranslateToXmlMenu(menu);

            
        }

        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);
        }

        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }

        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {

            return (State)menu.Update(gameTime);
        }

        public static void RunDraw(SpriteBatch spriteBatch)
        {
            
        }
        
        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }

            return State.HighScore;
        }

        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }


        public static State CurrentState { get { return currentState; } set { currentState = value; } }
        public static PrintText DebugPrint { get { return printText; }set { printText = value; } }
    }
}
