using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// represents the player ingame.
    /// </summary>
    static class PlayerController
    {
        static private float       currency = 500;
        static private float       hp = 100f;
        static private SpriteFont  font;
        static private PrintText   hpDisplay;
        static private PrintText   currencyDisplay;
        static private SpriteBatch spriteBatch;
        //initilize the base state of the player.
        static public void Initalize(SpriteBatch sprite)
        { 
            hpDisplay = new PrintText(font,25,25);
            currencyDisplay = new PrintText(font,25,50);
            spriteBatch = sprite;
            hpDisplay.Print(spriteBatch, "Hp: " + hp);
            currencyDisplay.Print(spriteBatch, "Coins: " + currency);
        }
       
        //adds currency to the player.
        public static void CurrencyIncrease()
        {
            currency += 50;
        }
        //removes hp from the player.
        public static void TakeDamage()
        {
            hp -= 3;
           
        }
        //resets the player stats when the user goes back to the main menu.
        public static void Reset()
        {
            hp = 100;
            currency = 500;
        }
        //draws the hp and currency counters to the screen.
        public static void draw(SpriteBatch spriteBatch)
        {

            hpDisplay.Print(spriteBatch, "Hp: " + hp);
            currencyDisplay.Print(spriteBatch, "Coins: " + currency);
            if(hp < 1)
            {
                PrintText deathText = new PrintText(font, 600, 600);
                deathText.Print(spriteBatch, "Game Over please press esc to go back to the menu and select a new map");
            }
        }

        #region Attributes

        static public float Hp { get { return hp; } set { } }
        static public float Currency { get { return currency; } set { currency = value; } }
        static public SpriteFont Font { get { return font; } set { font = value; } }

        #endregion


    }


}
