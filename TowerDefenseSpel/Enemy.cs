using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// base class for all enemies in the game written in a way so it is easy to add more enemies at a later date.
    /// </summary>
    abstract class Enemy : VisibleGameobject
    {
        protected float hp;
        protected PathPoint currentPath;
        protected float damage;
        public Action OnEnemyDeath;
        protected double distanceToChange = 3.4;
        protected int movementSpeed = 1;

        protected abstract void Movment();

        public Enemy(Texture2D texture, int x, int y) : base(texture, x, y) 
        {
        }

        public virtual void TakeDamage(float amount)
        {
            hp -= amount;
            if(hp< 0 && OnEnemyDeath != null)
            {
                OnDeath();
            }
        }

        public virtual void Update(SpriteBatch spriteBatch)
        {
            Movment();
            Draw(spriteBatch);
        }

        public void Stop()
        {
            movementSpeed = 0;
        }

        public void Start()
        {
            movementSpeed = 1;
        }

        public abstract void OnDeath();

        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.Texture != null)
            {
                spriteBatch.Draw(this.Texture, new Vector2(this.X, this.Y), Color.White);
            }
            
        }

        //get the distance betwwen the current position and the position of  the pathpoint which is the target.
        public double Distance(Vector2 currentPosition)
        {
            float deltaX = currentPosition.X - currentPath.X;
            float deltaY = currentPosition.Y - currentPath.Y;
            float distanceSquared = deltaX * deltaX + deltaY * deltaY;
            return Math.Sqrt(distanceSquared);
        }

        #region Attributes

        public float Hp { get; set; }
        public float Damage { get; set; }

        #endregion

    }
}
