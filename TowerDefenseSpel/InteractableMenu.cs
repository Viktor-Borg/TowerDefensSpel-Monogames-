using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseSpel
{
    /// <summary>
    /// Is responsible for taking in interactableitems and organize them into a menu which then can be displayed to the user. 
    /// </summary>
    class InteractableMenu
    {
        private string[] mapNames;
        InteractableItem[] menuItems;
        private const int space = 50;
        private const int posistionX = 300;
        //takes in all the interactable items and organize them and then put them into an array.
        public InteractableMenu(string[] names,SpriteFont font)
        {
            mapNames = names;
            menuItems = new InteractableItem[mapNames.Length];
            for (int i = 0; i < mapNames.Length; i++)
            {
                InteractableItem temp = new InteractableItem(posistionX, (i + 1) * space, mapNames[i],font);
                menuItems[i] = temp;
            }
        }

        //calls the update method on all items in the menu.
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(InteractableItem item in menuItems)
            {
                item.Update(spriteBatch);
            }
        }

        //is used when the user goes back to the manin menu to reset the menu.
        public void Reset()
        {
            foreach(InteractableItem item in menuItems)
            {
                item.HasAlreadyClicked = false;
            }
        }
    }
}
