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
        protected Action OnEnemyDeath;

        protected abstract void Movment();

        public Enemy(Texture2D texture, int x, int y) : base(texture, x, y) 
        {
            currentPath.OnHit += ChangePath;
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

        public void ChangePath()
        {
            currentPath.OnHit += ChangePath;
        }

        public float Hp { get; set; }
        public float Damage { get; set; }
    }
}
