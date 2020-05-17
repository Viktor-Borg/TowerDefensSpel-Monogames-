using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// base class for all towers ingame.
    /// </summary>
    abstract class Tower : VisibleGameobject
    {
        public enum TowerType {none, standardTower,}

        protected Enemy  target;
        protected float  range;
        protected float  damage;
        protected double fireCooldown;
        protected double lastTimeFired;
        protected int    buyCost;
        private   bool   isActive = true;
        protected ObjectPooling<Projectile> projectiles;
        private delegate void OnHit(Projectile projectile);
        private List<Projectile> activeProjectiles = new List<Projectile>();

        public abstract TowerType towerType { get;}
        //takes in the texture,position and projectile texture of this tower instance.
        public Tower(Texture2D texture, int x, int y,Texture2D projectileTexture) : base(texture, x, y) 
        {
            Projectile[] temp = new Projectile[500];
            for(int i = 0; i<temp.Length; i++)
            {
                temp[i] = new Projectile(2, projectileTexture, x, y);
            }
            projectiles = new ObjectPooling<Projectile>(temp);
        
        }
        //called when the tower fires and grabs a projectile and asign the correct method to the delegate and then calls the projectiles launch method.
        public virtual void OnFire()
        {
            Projectile currentProjectile = projectiles.GrabObject();
            OnHit onHit = new OnHit(ReturnProjectile);
            currentProjectile.Launch(target, this,onHit);
            activeProjectiles.Add(currentProjectile);
        }
        //responsible  for returning the projectile once it has hit the enemy.
        public void ReturnProjectile(Projectile projectile)
        {
            projectile.X = this.x;
            projectile.Y = this.y;
            activeProjectiles.Remove(projectile);
            projectiles.AddStoredObject(projectile);
        }
        //responsible for checking if the target is in range and if not call the getnewtarget method. Also responsible for calling the update method on all active projectiles and if there is a target in range to call the onfire method.
        public virtual void Update(GameTime gamtime,SpriteBatch spriteBatch)
        {
            if(target == null ) 
            {
                target = GetNewTarget();
            }
            else
            {
               
                if(Distance(target) > range || target.Texture == null)
                {
                    target = GetNewTarget();
                }
            }
            for (int i = 0; i < activeProjectiles.Count; i++)
            {
                activeProjectiles[i].Update(spriteBatch);
            }

            if (target != null && gamtime.TotalGameTime.TotalMilliseconds > lastTimeFired + fireCooldown && isActive)
            {
                lastTimeFired = gamtime.TotalGameTime.TotalMilliseconds;
                OnFire();
            }
           

            Draw(spriteBatch);


        }
        //gets a new target.
        private Enemy GetNewTarget()
        {
            Enemy[] enemies = WaveController.enemies;
            foreach(Enemy enemy in enemies)
            {
                if(Distance(enemy)< range && enemy.Texture != null)
                {
                    return enemy;
                }
            }
            return null;
        }
        //gets the distance between the tower and the enemy.
        public double Distance(Enemy enemy)
        {
            Vector2 temp = new Vector2((this.X - enemy.X) * (this.X - enemy.X), (this.Y - enemy.Y) * (this.Y - enemy.Y));
            return Math.Sqrt(temp.X + temp.Y);
        }

        //draws the tower.
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Vector2(this.X, this.Y), Color.White);
           
        }

        #region Attributes

        public int BuyCost { get { return buyCost; } }
        public float Damage { get { return damage; } }

        #endregion


    }
}
