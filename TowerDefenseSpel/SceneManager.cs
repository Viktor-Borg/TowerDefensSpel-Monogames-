using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseSpel.MapGeneration;

namespace TowerDefenseSpel
{
    /// <summary>
    /// responsible for changing game states.
    /// </summary>
    static class SceneController 
    {
        static private Menu      menu;
        static private PrintText printText;


        public enum State : byte{Menu, LevelPicker, HighScore, Quit,MapGeneration, Game };

        static private State currentState;

          
        //loadsin the menu and saves the different states in an array.
        static public void LoadContent(ContentManager content, GameWindow window)
        {
            byte[] states = new byte[3];
            for(int i = 0; i< states.Length; i++)
            {
                states[i] = (byte)(i + 1);
            }

            menu = XmlReader.LoadMenuScene("Mapdata.xml", states, content, 0);
            
        }
        
        static public State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);
        }

        static public void MenuDraw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }

        static public State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {

            return (State)menu.Update(gameTime);
        }


        #region Attributes

        static public State CurrentState { get { return currentState; } set { currentState = value; } }

        #endregion


    }
}
