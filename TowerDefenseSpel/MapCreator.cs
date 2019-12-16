using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.MapGeneration
{
    static class MapCreator
    {
        static Dictionary<string, List<int[,]>> tilePlacement = new Dictionary<string, List<int[,]>>();
        static List<int[,]> positionGrass = new List<int[,]>();
        static List<int[,]> positionWater = new List<int[,]>();
        static List<int[,]> positionRoad  = new List<int[,]>();

        static void AddTile(Vector2 position, Texture2D texture)
        {

        }

        static void RemoveTile(Vector2 position)
        {

        }

        static void AddPowersource(Vector2 position)
        {

        }

        static void RemovePowersource(Vector2 position)
        {

        }

        static void AddPathPoint (Vector2 posiion)
        {

        }

        static void RemovePathPoint(Vector2 position)
        {

        }

        static void SaveMap(string sceneName)
        {
            
        }
    }
}
