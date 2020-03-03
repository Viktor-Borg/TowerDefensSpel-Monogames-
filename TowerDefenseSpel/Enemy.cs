using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    abstract class Enemy : VisibleGameobject, IKillable
    {
        protected float hp;
        protected PathPoint currentPath;
        protected float damage;
        public Action OnEnemyDeath;
        protected double distanceToChange = 3.4;

        protected abstract void Movment();

        public Enemy(Texture2D texture, int x, int y) : base(texture, x, y) 
        {
        }

        public virtual void TakeDamage(float amount)
        {
            hp -= amount;
            if(hp< 0 && OnEnemyDeath != null)
            {
                OnEnemyDeath.Invoke();
            }
        }

        public virtual void Update(SpriteBatch spriteBatch)
        {
            Movment();
            Draw(spriteBatch);
        }

        public abstract void OnDeath();

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.Texture != null)
            {
                spriteBatch.Draw(this.Texture, new Vector2(this.X, this.Y), Color.White);
            }
            
        }

        public double Distance(Vector2 currentPosition)
        {
            float deltaX = currentPosition.X - currentPath.X;
            float deltaY = currentPosition.Y - currentPath.Y;
            float distanceSquared = deltaX * deltaX + deltaY * deltaY;
            return Math.Sqrt(distanceSquared);
        }

        public float Hp { get; set; }
        public float Damage { get; set; }
    }
}
