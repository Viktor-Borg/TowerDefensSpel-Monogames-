using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.GamePlay
{
    static class TowerController 
    {
       static private List<Tower> towers = new List<Tower>();
       
       static public List<Action> uppgrade = new List<Action>();
        
       static private Texture2D[] textures;

        static public void Update(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach(Tower tower in towers)
            {
                tower.Update(gameTime);
                tower.Draw(spriteBatch);
            }
        }

        static public void BuyNewTower(Tower tower,int x, int y)
        {
            if(PlayerController.Currency > tower.BuyCost)
             {  
                PlayerController.Currency -= tower.BuyCost;
                
                byte towerType = (byte)tower.towerType;
                switch (towerType)
                {
                    case 0:
                        StandardTower temp = new StandardTower(textures[0], x, y);
                        towers.Add(temp);
                        break;
                    default:
                        break;
                   

                }

            }
        }
    }
}
