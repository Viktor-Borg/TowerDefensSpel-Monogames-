using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// controlls all the uielements for buying new towers.
    /// </summary>
    static class UITowerController
    {
        private static int selectedTowertype;
        private static Texture2D[] texturesTowers;
        private static Texture2D textureProjectile;
        private static bool menuActive = false;
        private static bool hasSelected = false;
        private static bool hasPlaced = false;
        //initliaze the class.
        public static void Initilalize(Texture2D[] towerTextures,Texture2D projectileTexture)
        {
            texturesTowers = towerTextures;
            textureProjectile = projectileTexture;
        }
        //checks if the user have pressed the b button.
        public static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (menuActive)
            {
                SelectTower(keyboardState);
            }
            else if (keyboardState.IsKeyDown(Keys.B))
            {

                menuActive = true;
              
              
            }

        }
      
        //checks if the user have pressed the b key is formed in a way so it can be expanded later to account for more then one tower type.
        public static void SelectTower(KeyboardState keyboardState)
        {
            if (hasSelected)
            {
                PlaceTower();
            }
            else if (keyboardState.IsKeyDown(Keys.B))
            {
                selectedTowertype = 0;
                hasSelected = true;
            }
           
        }
        //places the tower  at the position where the user pressed left mouse button.
        public static void PlaceTower()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                TowerController.BuyNewTower(new StandardTower(texturesTowers[0], mouseState.Position.X, mouseState.Position.Y,textureProjectile));
                hasPlaced = true;
            }
            if (hasPlaced)
            {
                menuActive = false;
                hasSelected = false;
                hasPlaced = false;
                
            }
        }


    }
}
