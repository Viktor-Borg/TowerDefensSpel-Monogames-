using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel
{
    /// <summary>
    /// oraginze PrinText into larger texts so it can easily be displayed to the user.
    /// </summary>
    class TextPage
    {
        private PrintText[] lines;
        private string[] textLines;
        //sets all the text lines and printtexts used buy this instance.
        public TextPage(PrintText[] outPutLines,string[]outPutTextLines)
        {
            lines = outPutLines;
            textLines = outPutTextLines;
        }

       
        //Draws the printtext objects with the correpsonding line of text.
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i].Print(spriteBatch, textLines[i]);
            }
        }
    }
}
