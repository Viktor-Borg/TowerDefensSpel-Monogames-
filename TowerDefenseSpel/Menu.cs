using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel
{
    /// <summary>
    /// takes menu items and organize them into a menu.
    /// </summary>
    class Menu
    {
        MenuItem[] menu;
        int        selected = 0;
        int        amountOfElements = 0;

        float  currentHeight = 0;
        double lastChange = 0;
        byte   defaultMenuState = 0;

        int k = 0;
        //take in the default state of the menu and the amount of menu items the mennu will contain.
        public Menu(byte defaultMenuState, int amountOfElements)
        {
            menu                  = new MenuItem[amountOfElements];
            this.amountOfElements = amountOfElements;
            this.defaultMenuState = defaultMenuState;
        }
        //adds a menu item to the menu.
        public void AddItem(Texture2D itemTexture, byte state)
        {
            if(k < amountOfElements)
            {
                float X = 0;
                float y = 0 + currentHeight;

                currentHeight += itemTexture.Height + 20;

                MenuItem temp = new MenuItem(itemTexture, new Vector2(X, y), state);
                menu[k]       = temp;
                k++;
            }
            

        }
        //checks if the user have pressed the up or down key and if they have it changes the menu item in focus accordingly.also checks if the user presses enter and then return the coresponding state.
        public byte Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(lastChange + 130 < gameTime.TotalGameTime.TotalMilliseconds)
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    selected++;
                    if (selected > amountOfElements - 1)
                    {
                        selected = 0;
                    }
                    lastChange = gameTime.TotalGameTime.TotalMilliseconds;

                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    selected--;

                    if (selected < 0)
                    {
                        selected = amountOfElements - 1;
                    }
                    lastChange = gameTime.TotalGameTime.TotalMilliseconds;
                }
                
            }

           


            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                return menu[selected].State;
            }
            return defaultMenuState;
        }
        
        //draws the menu on the screen.
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <menu.Length; i++)
            {
                if(i == selected)
                {
                    spriteBatch.Draw(menu[i].Texture, menu[i].Position, Color.RosyBrown);
                }
                else
                {
                    spriteBatch.Draw(menu[i].Texture, menu[i].Position, Color.White);
                }
            }
           
        }

        #region Attributes

        public MenuItem[] Meny { get { return menu; } set { menu = value; } }

        #endregion


    }
}
