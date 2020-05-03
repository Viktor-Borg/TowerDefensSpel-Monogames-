using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseSpel.MapGeneration;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel
{
    /// <summary>
    /// Used for taking inputs from the user.
    /// </summary>
    static class InptController
    {
        private static SpriteFont font;
        private static string mapName = "";
        private const double delay = 125;
        private static double lastTimeINput = 250;
        private static PrintText print;
        private static PrintText printName;
        private static bool      isNameDone = false;
        public static void initialize(SpriteFont spriteFont)
        {
            font = spriteFont;
           
        }
        //this methods writes out the instruction to the user aswell as the current name they have written.
        public static void MapUDrawpdate(SpriteBatch spriteBatch)
        {
            print = new PrintText(font, 500, 500);
            print.Print(spriteBatch,"Please enter your map name press rightshift when the name is fully entered.(note that if the name already exist it will not be a valid name)");
            if(mapName != null)
            {
                printName = new PrintText(font, 500, 550);
                printName.Print(spriteBatch, MapName);
            }

        }
        //this method checks which button the user has pressed and if adds it to the mapname variable.
        public static bool InputUpdate(GameTime gametime)
        {

            if(lastTimeINput + delay < gametime.TotalGameTime.TotalMilliseconds && !isNameDone)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    mapName += "a";
                }
                else if (keyboardState.IsKeyDown(Keys.B))
                {
                    mapName += "b";
                }
                else if (keyboardState.IsKeyDown(Keys.C))
                {
                    mapName += "c";
                }
                else if (keyboardState.IsKeyDown(Keys.D))
                {
                    mapName += "d";
                }
                else if (keyboardState.IsKeyDown(Keys.E))
                {
                    mapName += "e";
                }
                else if (keyboardState.IsKeyDown(Keys.F))
                {
                    mapName += "f";
                }
                else if (keyboardState.IsKeyDown(Keys.G))
                {
                    mapName += "g";
                }
                else if (keyboardState.IsKeyDown(Keys.H))
                {
                    mapName += "h";
                }
                else if (keyboardState.IsKeyDown(Keys.I))
                {
                    mapName += "i";
                }
                else if (keyboardState.IsKeyDown(Keys.J))
                {
                    mapName += "j";
                }
                else if (keyboardState.IsKeyDown(Keys.K))
                {
                    mapName += "k";
                }
                else if (keyboardState.IsKeyDown(Keys.L))
                {
                    mapName += "l";
                }
                else if (keyboardState.IsKeyDown(Keys.M))
                {
                    mapName += "m";
                }
                else if (keyboardState.IsKeyDown(Keys.N))
                {
                    mapName += "n";
                }
                else if (keyboardState.IsKeyDown(Keys.O))
                {
                    mapName += "o";
                }
                else if (keyboardState.IsKeyDown(Keys.P))
                {
                    mapName += "p";
                }
                else if (keyboardState.IsKeyDown(Keys.Q))
                {
                    mapName += "q";
                }
                else if (keyboardState.IsKeyDown(Keys.R))
                {
                    mapName += "r";
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    mapName += "s";
                }
                else if (keyboardState.IsKeyDown(Keys.T))
                {
                    mapName += "t";
                }
                else if (keyboardState.IsKeyDown(Keys.U))
                {
                    mapName += "u";
                }
                else if (keyboardState.IsKeyDown(Keys.V))
                {
                    mapName += "v";
                }
                else if (keyboardState.IsKeyDown(Keys.W))
                {
                    mapName += "w";
                }
                else if (keyboardState.IsKeyDown(Keys.X))
                {
                    mapName += "x";
                }
                else if (keyboardState.IsKeyDown(Keys.Y))
                {
                    mapName += "y";
                }
                else if (keyboardState.IsKeyDown(Keys.Z))
                {
                    mapName += "z";
                }
                else if (keyboardState.IsKeyDown(Keys.Back))
                {
                    if(mapName.Length > 0)
                    {
                       mapName = mapName.Remove(mapName.Length - 1, 1);
                    }
                    
                }
                else if (keyboardState.IsKeyDown(Keys.RightShift))
                {
                    isNameDone = true;
                    return true;
                }
                lastTimeINput = gametime.TotalGameTime.TotalMilliseconds;
                
            }
            return false;





        }

        #region Attributes

        public static string MapName { get { return mapName; } set { mapName = value; } }
        public static bool IsNameDone { get { return isNameDone; } set { isNameDone = value; } }

        #endregion


    }
}
