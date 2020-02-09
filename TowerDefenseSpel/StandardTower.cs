using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    class StandardTower : Tower
    {
        private TowerType thisTowerType = TowerType.standardTower;
       

        public StandardTower(Texture2D texture, int x, int y) : base(texture, x, y)
        {
            this.damage = 10;
            this.range = 100;
            this.fireCooldown = 200;
        }

        public override void Uppgrade(UppgradeType uppgrade,float amountToUppgrade)
        {
            if(uppgrade == UppgradeType.damage)
            {
                this.damage += amountToUppgrade;
            }
            else if(uppgrade == UppgradeType.Firerate)
            {
                this.fireCooldown -= amountToUppgrade;
            }
            else if(uppgrade == UppgradeType.Range)
            {
                this.range += amountToUppgrade;
            }
            
        }

        public override TowerType towerType { get { return thisTowerType; } }
    }
}
