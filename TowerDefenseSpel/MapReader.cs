using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefenseSpel.MapGeneration
{
    static class XmlReader
    {
        static XmlDocument mapData = new XmlDocument();

        #region MenyMetoder

        static void ReadFile()
        {
            mapData.Load("Mapdata.xml");
        }


        public static void TranslateToXmlMenu(Menu menu)
        {
            XmlElement menuItems = mapData.CreateElement("MenuItems");
            mapData.AppendChild(menuItems);
            for (int i = 0; i < menu.Meny.Length; i++)
            {
                XmlElement menuItem = mapData.CreateElement("MenuItem");
                menuItem.InnerText  = menu.Meny[i].Texture.Name;
                menuItems.AppendChild(menuItem);
            }
            mapData.Save("Mapdata.xml");
        }

        public static Menu LoadMenuScene(string sceneId, byte[] states, ContentManager content, byte defaultState)
        {
            Menu meny             = new Menu(defaultState, states.Length);
            XmlDocument tempMenu  = new XmlDocument();
            tempMenu.Load(sceneId);
            XmlNodeList menuItems = tempMenu.SelectNodes("MenuItems/MenuItem");

            int i = 0;
            foreach (XmlNode menuItem in menuItems)
            {
                try
                {
                    meny.AddItem(content.Load<Texture2D>(menuItem.InnerText), states[i]);
                    i++;
                }
                catch (System.IndexOutOfRangeException e)
                {
                    return null;
                }
            }

            return meny;

        }


        #endregion

        #region MapMetoder

        public static void TranslateToXmlMap(Map map, string mapName)
        {
            XmlDocument tempMap = new XmlDocument();
            XmlElement mapData = tempMap.CreateElement("MapData");
            XmlElement Tiles = tempMap.CreateElement("Tiles");
            XmlElement pathPoints = tempMap.CreateElement("PathPoints");
          
            tempMap.AppendChild(mapData);
            mapData.AppendChild(Tiles);
            mapData.AppendChild(pathPoints);
            

            for (int i = 0; i < map.MapTiles.Length; i++)
            {
                XmlElement Tile = tempMap.CreateElement("Tile");
                Tile.InnerText = "x: " + map.MapTiles[i].X + " y: " + map.MapTiles[i].Y + " Type: " + (int)map.MapTiles[i].Type + " size: " + map.MapTiles[i].Size;
                Tiles.AppendChild(Tile);
            }
            foreach (PathPoint pathPoint in map.PathPoints)
            {
                XmlElement PathPoint = tempMap.CreateElement("PahtPoint");
                PathPoint.InnerText = "x: " + pathPoint.X + " y: " + pathPoint.Y;
                pathPoints.AppendChild(PathPoint);
            }
            tempMap.Save(mapName + ".xml");
        }

        public static Map LoadMapScene(string sceneName)
        {
            XmlDocument temp = new XmlDocument();
            temp.Load(sceneName + ".xml");

            XmlNodeList tileSet = temp.SelectNodes("MapData/Tiles/Tile");
            XmlNodeList pathpoints = temp.SelectNodes("MapData/PathPoints/PahtPoint");

            List<Tile> tiles = new List<Tile>();
            List<PathPoint> pathPoints = new List<PathPoint>();

            foreach(XmlNode tile in tileSet)
            {
                string[] tempString = tile.InnerText.Split(' ');
                Tile tempTile = new Tile(int.Parse(tempString[7]), (Type)int.Parse(tempString[5]), new Vector2(float.Parse(tempString[1]), float.Parse(tempString[3])));
                tiles.Add(tempTile);
            }
            foreach(XmlNode pathPoint in pathpoints)
            {
                string[] tempString = pathPoint.InnerText.Split(' ');
                PathPoint tempPoint = new PathPoint(int.Parse(tempString[1]), int.Parse(tempString[3]));
                pathPoints.Add(tempPoint);
            }

            Map map = new Map(tiles.ToArray(), pathPoints.ToArray());
            return map;

        }

        #endregion


    }

}
