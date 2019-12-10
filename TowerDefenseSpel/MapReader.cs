using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseSpel.MapGeneration
{
    static class XmlReader
    {
        static XmlDocument mapData = new XmlDocument();
        
        static void ReadFile()
        {
            mapData.Load("Mapdata.xml");
        }

        static void TranslateToXmlMap(TileSet map)
        {
            //xml
        }

        public static void TranslateToXmlMenu(Menu menu)
        {
            XmlElement menuItems = mapData.CreateElement("MenuItems");
            mapData.AppendChild(menuItems);
            for (int i = 0; i < menu.Meny.Length; i++)
            {
                XmlElement menuItem = mapData.CreateElement("MenuItem");
                menuItem.InnerText = menu.Meny[i].Texture.Name;
                menuItems.AppendChild(menuItem);
            }
            mapData.Save("Mapdata.xml");
        }

        public static Menu LoadMenuScene(string sceneId,byte[] states,ContentManager content, byte defaultState)
        {
            Menu meny = new Menu(defaultState, states.Length);
            XmlDocument tempMenu = new XmlDocument();
            tempMenu.Load(sceneId);
            XmlNodeList menuItems = tempMenu.SelectNodes("MenuItems/MenuItem");
                
            int i = 0;
            foreach(XmlNode menuItem in menuItems)
            {
                try
                {
                    meny.AddItem(content.Load<Texture2D>(menuItem.InnerText), states[i]);
                    i++;
                }
                catch(System.IndexOutOfRangeException e)
                {
                    return null; 
                }
            }

            return meny;

        }

        public static void TranslateToXmlMap(Map map, string mapName)
        {
            XmlDocument tempMap = new XmlDocument();
            XmlElement Tiles = tempMap.CreateElement("Tiles");
            XmlElement pathPoints = tempMap.CreateElement("PathPoints");
            XmlElement powersources = tempMap.CreateElement("Powersources");
            XmlElement mapdata = tempMap.CreateElement("Map");
            tempMap.AppendChild(mapdata);
            mapdata.AppendChild(Tiles);
            mapdata.AppendChild(pathPoints);
            mapdata.AppendChild(powersources);

            for(int i = 0; i<map.TileSet.PlatserY; i++)
            {
                for(int j = 0; j<map.TileSet.PlatserX; j++)
                {
                    XmlElement Tile = tempMap.CreateElement("Tile");
                    Tile.InnerText = "x: " + j + " y: " + i;
                    Tiles.AppendChild(Tile);
                }
            }
            foreach(PathPoint pathPoint in map.PathPoints)
            {
                XmlElement PathPoint = tempMap.CreateElement("PahtPoint");
                PathPoint.InnerText = "x: " + pathPoint.X + " y: " + pathPoint.Y;
                pathPoints.AppendChild(PathPoint);
            }
            foreach(Powersource powersource in map.Powersources)
            {
                XmlElement PowerSource = tempMap.CreateElement("PowerSource");
                PowerSource.InnerText = "x: " + powersource.X + " y: " + powersource.Y;
                powersources.AppendChild(PowerSource);
            }
            tempMap.Save(mapName + ".xml");
        }

      /*  public static Map LoadMapScene(Tile backgroundTiles, PathPoint[] pathPoints, Powersource[] powersources, string sceneName)
        {

        }*/

    }

}
