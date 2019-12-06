using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel
{
    class Menu
    {
        MenuItem[] menu;
        int selected = 0;
        int amountOfElements = 0;

        float currentHeight = 0;
        double lastChange = 0;
        byte defaultMenuState = 0;

        int k = 0;

        public Menu(byte defaultMenuState, int amountOfElements)
        {
            menu = new MenuItem[amountOfElements];
            this.amountOfElements = amountOfElements;
            this.defaultMenuState = defaultMenuState;
        }

        public void AddItem(Texture2D itemTexture, byte state)
        {
            if(k < amountOfElements)
            {
                float X = 0;
                float y = 0 + currentHeight;

                currentHeight += itemTexture.Height + 20;

                MenuItem temp = new MenuItem(itemTexture, new Vector2(X, y), state);
                menu[k] = temp;
                k++;
            }
            

        }

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
            SceneManager.DebugPrint.Print(menu[0].Texture.Name,spriteBatch,300,300);
        }

        public MenuItem[] Meny { get { return menu; } set { menu = value; } }
    }
}
