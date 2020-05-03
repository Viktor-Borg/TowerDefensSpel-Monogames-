using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseSpel.GamePlay;

namespace TowerDefenseSpel
{/// <summary>
/// is the projectile used by towers in the game.
/// </summary>
    class Projectile : VisibleGameobject , Iinteractable
    {
        private float projectileDamage;
        private Enemy targetedEnemy;
        private Tower originTower;
        private const int movementSpeed = 1;
        private Delegate OnHit;
        //takes in the texture damage and position of the projectile
        public Projectile(float damage, Texture2D texture, int x,int y) : base(texture, x, y)
        {
            projectileDamage = damage;
        }
        //called when the tower launches the projectile and takes in the oring of the projectile as well as the target and a method which is to be called once the projectile interacts with an enemy.
        public void Launch(Enemy target,Tower origin, Delegate @delegate)
        {
            targetedEnemy = target;
            originTower = origin;
            OnHit = @delegate;
        }
        //responsbile for calling the draw method as well as moving the projectile closer to the enemy and check if the projcetile has hit an enemy.
        public void Update(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
            if(targetedEnemy.X > this.x)
            {
                this.x += movementSpeed;
            }
            else if(targetedEnemy.X < this.x)
            {
                this.x -= movementSpeed;
            }

            if(targetedEnemy.Y > this.y)
            {
                this.y += movementSpeed;
            }
            else if(targetedEnemy.Y < this.y)
            {
                this.y -= movementSpeed;
            }

            if(targetedEnemy.X == this.x && targetedEnemy.Y < this.y)
            {
                this.y -= movementSpeed;
            }
            else if(targetedEnemy.X == this.x && targetedEnemy.Y > this.y)
            {
                this.y += movementSpeed;
            }
            else if(targetedEnemy.Y == this.y && targetedEnemy.X < this.x)
            {
                this.x -= movementSpeed;
            }
            else if(targetedEnemy.Y == this.y && targetedEnemy.X > this.x)
            {
                this.x += movementSpeed;
            }

            if(Distance(targetedEnemy) < 5)
            {
                Oninteract();
            }

            
        }
        //draws the enemy.
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(x,y), Color.White);
        }
        //is called once the proectile has hit the target and calls the take damage method on the target plus invokes the onhit delegate.
        public void Oninteract()
        {
            targetedEnemy.TakeDamage(projectileDamage * originTower.Damage);
            OnHit.DynamicInvoke(this);

        }

       
        //gets the distance betwwen the projectile and the target.
        private double Distance(Enemy target)
        {
            return Math.Sqrt((target.X - this.x) * (target.X - this.x) + (target.Y - this.y) * (target.Y - this.y));
        }

      
    }
}
