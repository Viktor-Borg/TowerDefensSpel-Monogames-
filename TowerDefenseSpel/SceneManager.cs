using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseSpel.MapGeneration;

namespace TowerDefenseSpel
{
    static class SceneController 
    {
        static private Texture2D menuSprite;
        static private Vector2   menuPos;
        static private Menu      menu;
        static private PrintText printText;
        static private Texture2D grassTile;
        static private Map       tempMap;

        public enum State : byte{Menu, LevelPicker, HighScore, Quit,MapGeneration, Game };

        static private State currentState;

        

        static public void LoadContent(ContentManager content, GameWindow window)
        {
            byte[] states = new byte[3];
            for(int i = 0; i< states.Length; i++)
            {
                states[i] = (byte)(i + 1);
            }

            menu = XmlReader.LoadMenuScene("Mapdata.xml", states, content, 0);

           /* grassTile = content.Load<Texture2D>("grass");
            int tileSizeX = grassTile.Width;
            int tileSizeY = grassTile.Height;

            Vector2 windowSize = new Vector2(window.ClientBounds.Width, window.ClientBounds.Height);

            TileSet temp = new TileSet(windowSize, new Vector2(tileSizeX, tileSizeY), content, grassTile);

            Powersource[] tempSource = new Powersource[2];
            tempSource[0] = new Powersource(grassTile, 200, 200);
            tempSource[1] = new Powersource(grassTile, 300, 300);

            PathPoint[] tempPoints = new PathPoint[2];
            tempPoints[0] = new PathPoint(150, 150);
            tempPoints[1] = new PathPoint(100, 150);

            tempMap = new Map(temp, tempPoints, tempSource);
         
 */           
            //XmlReader.TranslateToXmlMap(tempMap, "Test");

           // XmlReader.TranslateToXmlMenu(menu);

            
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

        static public void RunDraw(SpriteBatch spriteBatch)
        {
            
        }
        
        static public State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }

            return State.HighScore;
        }

        static public void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }


        static public State     CurrentState { get { return currentState; } set { currentState = value; } }
        static public PrintText DebugPrint { get { return printText; }set { printText = value; } }
    }
}
