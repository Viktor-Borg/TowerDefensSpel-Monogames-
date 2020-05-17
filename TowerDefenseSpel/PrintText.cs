using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel
{
    class PrintText : Gameobject
    {
        private SpriteFont font;
       

       
        public PrintText(SpriteFont font,int x, int y):base(x,y)
        {
            this.font = font;
           
        }

        public void Print(SpriteBatch spriteBatch,string text)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y),Color.White);
        }

        public void Print(SpriteBatch spriteBatch, string text,Color color)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y), color);
        }
    }
}
