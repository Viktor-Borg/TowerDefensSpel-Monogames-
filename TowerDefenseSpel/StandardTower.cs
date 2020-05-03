using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// the standard tower class derived from the tower class.
    /// </summary>
    class StandardTower : Tower
    {
        private TowerType thisTowerType = TowerType.standardTower;
       
        //sets the damage,range,firecooldown,buycost,texture,projectile texture used by this tower.
        public StandardTower(Texture2D texture, int x, int y,Texture2D projectileTexture) : base(texture, x, y,projectileTexture)
        {
            this.damage = 10;
            this.range = 100;
            this.fireCooldown = 1000;
            this.buyCost = 100;
        }

        #region Attributes

        public override TowerType towerType { get { return thisTowerType; } }

        #endregion

    }
}
