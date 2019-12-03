using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        static void TranslateToXmlMenu(Menu menu)
        {
            XmlElement menuItems = mapData.CreateElement("MenuItem");
            mapData.AppendChild(menuItems);
            for (int i = 0; i < menu.Meny.Length; i++)
            {
                //menu.Meny[i].Texture.Name;
            }
        }
    }
}
