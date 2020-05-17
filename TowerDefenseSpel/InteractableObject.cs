using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel
{
    /// <summary>
    /// the base class for all interactable objects in the game. 
    /// </summary>
    class InteractableObject : Gameobject
    {
        protected bool hasAlreadyClicked = false;
        private int width = 0;
        private int height = 0;
        private PrintText displayedText;
        protected string outPutText;

        //sets the width depending on the length of the text and sets the hight as a constant.
        public InteractableObject( int x, int y,string text,SpriteFont spriteFont) : base(x, y)
        {
            width = 12 * text.Length;
            height = 12;
            displayedText = new PrintText(spriteFont, x, y);
            outPutText = text;

        }

        //checks wether the user is howering this specific object or not.
        public void DrawUpdate(SpriteBatch spriteBatch)
        {
            if (IsTargeted())
            {
                OnInteractDraw(spriteBatch);
               
            }
            else
            {
                Draw(spriteBatch);
            }
        }

        //checks if the mouse position of the user is inside the bound of the object. 
        public bool IsTargeted()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.Position.X < X + width && mouseState.Position.X > X && mouseState.Position.Y < Y + height && mouseState.Position.Y > Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //checks wether or not the user has clicked the left mouse button.
        public bool HasClicked()
        {
            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //the normal draw method for when the user is not targeting the object.
        private void Draw(SpriteBatch spriteBatch)
        {
            displayedText.Print(spriteBatch, outPutText);

        }

        //the draw method for when the user is targeting this object.
        private void OnInteractDraw(SpriteBatch spriteBatch)
        {
            displayedText.Print(spriteBatch, outPutText, Color.Orange);
        }
    }
}
