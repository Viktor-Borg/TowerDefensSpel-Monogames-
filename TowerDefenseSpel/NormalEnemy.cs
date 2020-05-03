using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// class derived from enemy and is the standard enemy in the game.
    /// </summary>
    class NormalEnemy : Enemy
    {
        private PathPoint[] pathPoints;
        private bool isAlive;
        private int i = 0;
       

        //responsible for the movemnt of the enemy and makes it move towarads the current pathpoint and if it gets close enough changes target to the next. It also checks if the enemy has reached the last pathpoint and in that case invokes the OnEnemyDeath event.
        protected override void Movment()
        {
            if(i == 0)
            {
                currentPath = pathPoints[0];
                i++;
            }
            else
            {
                if(Distance(new Vector2(this.X,this.Y)) < distanceToChange)
                {
                    if(currentPath == pathPoints[pathPoints.Length- 1] && !WaveController.DeadEnemies.Contains(this))
                    {
                        OnEnemyDeath.Invoke();
                    }
                    else if(!WaveController.DeadEnemies.Contains(this))
                    {
                        currentPath = pathPoints[i];
                        i++;
                    }
                    
                }
            }
            
            if(this.X > currentPath.X)
            {
                this.X -= movementSpeed;
            }
            else if(this.X < currentPath.X)
            {
                this.X += movementSpeed;
            }
            else if(this.Y > currentPath.Y)
            {
                this.Y -= movementSpeed;
            }
            else if(this.Y < currentPath.Y)
            {
                this.Y += movementSpeed;
            }
            
        }
        //takes in the pathpoints this enemy will follow as well as the texture and starting position of the enemy.
        public NormalEnemy(PathPoint[] pathPoints, Texture2D texture, int x, int y) : base(texture, x, y)
        {
            this.pathPoints = pathPoints;
            this.OnEnemyDeath += OnDeath;
            this.hp = 25;
        }

        //this method is called when the enemy is killed or reaches the end and are responsible for removing the enemy from the screen.
        public override void OnDeath()
        {
            this.Texture = null;
            WaveController.DeadEnemies.Add(this);
            PlayerController.CurrencyIncrease();
        }
    }
}
