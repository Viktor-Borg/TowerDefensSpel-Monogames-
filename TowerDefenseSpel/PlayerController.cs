using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    static class PlayerController
    {
        static private float       currency = 0;
        static private float       hp = 100f;
        static private SpriteFont  font;
        static private PrintText   hpDisplay;
        static private PrintText   currencyDisplay;
        static private SpriteBatch spriteBatch;

        static public void Initalize(SpriteBatch sprite)
        { 
            hpDisplay = new PrintText(font);
            currencyDisplay = new PrintText(font);
            spriteBatch = sprite;
            hpDisplay.Print("Hp: " + hp, spriteBatch, 25, 25);
            currencyDisplay.Print("Coins: " + currency, spriteBatch, 50, 50);
        }
        static public void OnDeath()
        {
            
        }

        public static void CurrencyIncrease()
        {
            currency += 50;//placeholder
        }

        public static void TakeDamage()
        {
            hp -= 3;
        }

        public static void draw(SpriteBatch spriteBatch)
        {
            hpDisplay.Print("Hp: " + hp, spriteBatch, 25, 25);
            currencyDisplay.Print("Coins: " + currency, spriteBatch, 25, 50);
        }
        static float Hp { get { return hp; } set { } }
        static public float Currency { get { return currency; }set { currency = value; } }
        static public SpriteFont Font { get { return font; } set { font = value; } }

    }


}
