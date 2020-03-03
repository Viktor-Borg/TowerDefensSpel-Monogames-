using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.GamePlay
{
    class NormalEnemy : Enemy
    {
        private PathPoint[] pathPoints;
        private bool isAlive;
        private int i = 0;
        private int movementSpeed = 1;


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
                    if(currentPath == pathPoints[pathPoints.Length- 1])
                    {
                        OnEnemyDeath.Invoke();
                    }
                    else
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

        public NormalEnemy(PathPoint[] pathPoints, Texture2D texture, int x, int y) : base(texture, x, y)
        {
            this.pathPoints = pathPoints;
            this.OnEnemyDeath += OnDeath;
            this.hp = 25;
        }


        public override void OnDeath()
        {
            this.Texture = null;
            this.X = 0;
            this.Y = 0;
        }
    }
}
