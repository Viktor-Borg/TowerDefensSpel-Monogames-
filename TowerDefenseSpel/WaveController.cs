using System;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;
using System.Collections.Generic;

namespace TowerDefenseSpel.GamePlay
{
    /// <summary>
    /// controlls the enemies on each wave.
    /// </summary>
    static class WaveController
    {
        static private int                  wave = 1;
        static private ObjectPooling<Enemy> enemiePool;
        static private PathPoint[]          pathPoints;
        static private Texture2D[]          enemyTextures;
        static private bool                 hasBeenActivated = false;
        static private Timer                timer;
        static private int                  spawnedEnemies;
        static private int                  enemiesToSpawn;//placeholder
        static private List<Enemy>          deadEnemies = new List<Enemy>();

        //initilizes the class.
        static public void Initilazie(PathPoint[] points, Texture2D[] textures)
        {
            pathPoints        = points;
            enemyTextures     = textures;
            Enemy[] temp      = new Enemy[100];
            

            for(int i = 0; i<100; i++)
            {
                temp[i]               = new NormalEnemy(pathPoints, enemyTextures[0], pathPoints[0].X, pathPoints[0].Y);
                temp[i].OnEnemyDeath += PlayerController.TakeDamage;
                
            }
            enemiePool = new ObjectPooling<Enemy>(temp);

            NextWave();
            hasBeenActivated = true;
        }
        //updates all the active enemies and checks if the wave is over and if it is call the method to start the next wave.
        static public void Update(SpriteBatch spriteBatch)
        {
            if (hasBeenActivated)
            {
                for (int i = 0; i < enemiePool.ActiveObjects.Count; i++)
                {
                    enemiePool.ActiveObjects[i].Update(spriteBatch);
                }
                if(deadEnemies.Count == enemiesToSpawn && PlayerController.Hp > 0)
                {
                    deadEnemies.Clear();
                    NextWave();
                }
            }
            
        }
        //loads the next wave and calls the startspawn method.
        private static void NextWave()
        {
            enemiesToSpawn = wave * 10;
            wave++;
            StartSpawn();
        }
        //responsible for reseting the waves when the user goes back to the main menu.
        public static void Reset()
        {
            wave = 1;
            enemiePool.ActiveObjects.Clear();
            spawnedEnemies = 0;
            timer.Stop();
            timer.Dispose();
        }

    

        
        //responsible for setting up the timer method for enemies to spawn.
        public static void StartSpawn()
        {
            timer = new Timer(1500);
            timer.Elapsed += OnEnemySpawn;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
       
        //spawns enemies in a set time interval untill it has spawned all the enemies for the current wave.
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

        static public Enemy[] enemies { get { return enemiePool.ActiveObjects.ToArray(); } }
        static public List<Enemy> DeadEnemies { get { return deadEnemies; } set { deadEnemies = value; } }

        #endregion
    }
}
