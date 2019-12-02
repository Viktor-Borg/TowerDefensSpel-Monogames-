using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TowerDefenseSpel.MapGeneration
{
    static class MapReader
    {
        static XmlDocument mapData = new XmlDocument();
        
        static void ReadFile()
        {
            mapData.Load("Mapdata.xml");
        }

        static void TranslateToXml(TileSet map)
        {
            //xml
        }
    }
}
