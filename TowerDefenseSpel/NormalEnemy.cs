using Microsoft.Xna.Framework.Graphics;

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
                if(this.X >= currentPath.X || this.Y >= currentPath.Y)
                {
                    
                    currentPath = pathPoints[i];
                    i++;
                    currentPath.OnHit.Invoke();
                    
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
        }


        public override void OnDeath()
        {
            this.Texture = null;
            this.X = 0;
            this.Y = 0;
        }
    }
}
