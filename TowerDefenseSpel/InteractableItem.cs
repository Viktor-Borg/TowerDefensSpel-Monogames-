using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseSpel.MapGeneration;

namespace TowerDefenseSpel
{
    /// <summary>
    /// defines interactableitems are mainly used to define what happens if the user clicks on the object is also used in the interactablemenu class.
    /// </summary>
    class InteractableItem : InteractableObject, Iinteractable
    {

        public InteractableItem(int x, int y, string text,SpriteFont font) : base(x, y,text,font)
        {
        }

        public void Update(SpriteBatch spriteBatch)
        {
            base.DrawUpdate(spriteBatch);
            if(base.IsTargeted() && base.HasClicked() && !hasAlreadyClicked)
            {
                Oninteract();
                hasAlreadyClicked = true;
            }
        }

        public void Oninteract()
        {
            Map temp = XmlReader.LoadMapScene(outPutText);
            Game1.Map = temp;
            Game1.MapHasBeenSelected = true;
        }

        #region Attributes

        public bool HasAlreadyClicked { get { return hasAlreadyClicked; } set { hasAlreadyClicked = value; } }

        #endregion

    }
}
