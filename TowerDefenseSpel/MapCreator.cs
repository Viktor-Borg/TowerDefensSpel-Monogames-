using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.MapGeneration
{
    static class MapCreator
    {
        static private Texture2D                     selectedTexture;
        static private Type                          selectedType;
        static private List<Tile>                    currentTiles = new List<Tile>();
        static private List<PathPoint>               pathPoints = new List<PathPoint>();
        static private double                        timeDelay = 50f;
        static private double                        lastTimePlaced = 0;
        
        public static void MapCreatorUpdate(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            double CurrentTime = gameTime.TotalGameTime.TotalMilliseconds;

            if(mouseState.LeftButton == ButtonState.Pressed && CurrentTime > lastTimePlaced + timeDelay)
            {

                AddTile(mouseState.Position.ToVector2(), selectedTexture, selectedType);
                lastTimePlaced = gameTime.TotalGameTime.TotalMilliseconds;
                
            }

            UIMapReader.Drawtiles(currentTiles);

        }
        private static void AddTile(Vector2 position, Texture2D texture, Type type)
        {
            
            
            float d = texture.Width;
            float r = d / 2;

            Vector2 positionToBeDrawn = new Vector2((float)(Math.Floor(position.X / d) * d), (float)(Math.Floor(position.Y / d) * d));
            if(type != Type.pathPoint)
            {
                Tile temp = new Tile(texture.Width, type, positionToBeDrawn);
                currentTiles.Add(temp);
            }
            else
            {
                PathPoint temp = new PathPoint(position.X, position.Y);
                pathPoints.Add(temp);
            }

        }
   
        public static void SaveMap()
        {
            Map temp = new Map(currentTiles.ToArray(), pathPoints.ToArray());
            XmlReader.TranslateToXmlMap(temp, "TestMap");
        }

        #region Getters

        public static Texture2D SelectedTexture { get { return selectedTexture; } set { selectedTexture = value; } }
        public static Type      SelectedType { get { return selectedType; } set { selectedType = value; } }

        #endregion
    }
}
