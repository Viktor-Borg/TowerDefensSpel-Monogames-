using System;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.GamePlay
{
    static class WaveController//, IEnumerator
    {
        static private int                  wave;
        static private ObjectPooling<Enemy> enemiePool;
        static private PathPoint[]          pathPoints;
        static private Texture2D[]          enemyTextures;
        static private bool                 hasBeenActivated = false;
        static public Action[]              onEnemyDeathEvent;
        static public void Initilazie(PathPoint[] points, Texture2D[] textures)
        {
            pathPoints        = points;
            enemyTextures     = textures;
            Enemy[] temp      = new Enemy[100];
            onEnemyDeathEvent = new Action[100];

            for(int i = 0; i<100; i++)
            {
                temp[i]               = new NormalEnemy(pathPoints, textures[0], pathPoints[0].X, pathPoints[0].Y);
                onEnemyDeathEvent[i] += temp[i].OnDeath;
            }
            enemiePool = new ObjectPooling<Enemy>(temp);

            for(int i = 0; i< 100; i++)
            {
                enemiePool.ActivateObject(temp[i],enemyTextures[0]);
            }
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
       /* static IEnumerator EnemieSpawn()
        {
            
        }*/

        static public void SpawnEnemies()
        {

        }

        #region Attributes

        static public Enemy[] enemies { get { return enemiePool.ActiveObjects; } }

        #endregion
    }
}
