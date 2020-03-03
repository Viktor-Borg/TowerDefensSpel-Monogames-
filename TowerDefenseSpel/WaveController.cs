using System;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace TowerDefenseSpel.GamePlay
{
    static class WaveController//, IEnumerator
    {
        static private int                  wave;
        static private ObjectPooling<Enemy> enemiePool;
        static private PathPoint[]          pathPoints;
        static private Texture2D[]          enemyTextures;
        static private bool                 hasBeenActivated = false;
        static private Timer                timer;
        static private int                  spawnedEnemies;
        static private int                  enemiesToSpawn = 20;//placeholder
        static public void Initilazie(PathPoint[] points, Texture2D[] textures)
        {
            pathPoints        = points;
            enemyTextures     = textures;
            Enemy[] temp      = new Enemy[100];
            

            for(int i = 0; i<100; i++)
            {
                temp[i]               = new NormalEnemy(pathPoints, enemyTextures[0], pathPoints[0].X, pathPoints[0].Y);
                temp[i].OnEnemyDeath += PlayerController.CurrencyIncrease;
                temp[i].OnEnemyDeath += PlayerController.TakeDamage;
                
            }
            enemiePool = new ObjectPooling<Enemy>(temp);

            StartSpawn();
            hasBeenActivated = true;
        }

        static public void Update(SpriteBatch spriteBatch)
        {
            if (hasBeenActivated)
            {
                for (int i = 0; i < enemiePool.ActiveObjects.Length; i++)
                {
                    enemiePool.ActiveObjects[i].Update(spriteBatch);
                }
            }
            
        }

        public static void StartSpawn()
        {
            timer = new Timer(1500);
            timer.Elapsed += OnEnemySpawn;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
       

        private static void OnEnemySpawn(Object source, ElapsedEventArgs e)
        {
            Enemy toSpawn = enemiePool.GrabObject();
            toSpawn.X = pathPoints[0].X;
            toSpawn.Y = pathPoints[0].Y;
            spawnedEnemies++;
            if(spawnedEnemies == enemiesToSpawn)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        #region Attributes

        static public Enemy[] enemies { get { return enemiePool.ActiveObjects; } }

        #endregion
    }
}
