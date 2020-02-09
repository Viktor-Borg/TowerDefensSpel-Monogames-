using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    abstract class Tower : VisibleGameobject
    {
        public enum UppgradeType { damage, Firerate, Range }
        public enum TowerType { standardTower,}

        protected Enemy  target;
        protected float  range;
        protected float  damage;
        protected double fireCooldown;
        protected double lastTimeFired;
        protected int    buyCost;

        public abstract TowerType towerType { get;}

        public Tower(Texture2D texture, int x, int y) : base(texture, x, y) { }

        public virtual void OnFire()
        {
            target.TakeDamage(damage);
        }

        public virtual void Update(GameTime gamtime)
        {
            if(target == null)
            {
                target = GetNewTarget();
            }
            else
            {
               
                if(Distance(target) > range)
                {
                    target = GetNewTarget();
                }
            }

            if(target != null && gamtime.TotalGameTime.TotalMilliseconds > lastTimeFired + fireCooldown)
            {
                OnFire();
            }
        }

        private Enemy GetNewTarget()
        {
            Enemy[] enemies = WaveController.enemies;
            foreach(Enemy enemy in enemies)
            {
                if(Distance(enemy)< range)
                {
                    return enemy;
                }
            }
            return null;
        }

        public double Distance(Enemy enemy)
        {
            Vector2 temp = new Vector2((this.X - enemy.X) * (this.X - enemy.X), (this.Y - enemy.Y) * (this.Y - enemy.Y));
            return Math.Sqrt(temp.X + temp.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Vector2(this.X, this.Y), Color.White);
        }

        public abstract void Uppgrade(UppgradeType uppgrade, float amontToUppgrade);

        public int BuyCost { get { return buyCost; } }
    }
}
