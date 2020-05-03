using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// controlls all the active towers on the map.
    /// </summary>
    static class TowerController 
    {
       static private List<Tower> towers = new List<Tower>();
       
       
        
        //calls the update method on all active towers.
        static public void Update(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach(Tower tower in towers)
            {
                tower.Update(gameTime,spriteBatch);
                
            }
        }
        //clears the tower list once the user returns to the main menu.
        public static void Reset()
        {
            towers.Clear();
        }

      //buys new tower if the player have enough currency.
        static public void BuyNewTower(Tower tower)
        {
            if(PlayerController.Currency > tower.BuyCost)
             {  
                PlayerController.Currency -= tower.BuyCost;

                towers.Add(tower);

            }
        }
    }
}
