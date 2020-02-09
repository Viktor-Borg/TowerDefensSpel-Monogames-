using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.MapGeneration
{
    static class MapController 
    {
        static private Texture2D                     selectedTexture;
        static private Type                          selectedType;
        static private List<Tile>                    currentTiles = new List<Tile>();
        static private List<PathPoint>               pathPoints = new List<PathPoint>();
        static private double                        timeDelay = 50f;
        static private double                        lastTimePlaced = 0;
        static private BitArray2D                    isTileOccupied = new BitArray2D(1920/32 + 1,1080/32 + 1);

     
        static public void MapCreatorUpdate(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            double CurrentTime = gameTime.TotalGameTime.TotalMilliseconds;

            if(mouseState.LeftButton == ButtonState.Pressed)
            {

                AddTile(mouseState.Position.ToVector2(), selectedTexture, selectedType);
                lastTimePlaced = gameTime.TotalGameTime.TotalMilliseconds;
                
            }

            UIMapController.Drawtiles(currentTiles);

        }
        static private void AddTile(Vector2 position, Texture2D texture, Type type)
        {
            
            
            float d = texture.Width;
            float r = d / 2;

            Vector2 positionToBeDrawn = new Vector2((float)(Math.Floor(position.X / d) * d), (float)(Math.Floor(position.Y / d) * d));
            if(type != Type.pathPoint)
            {
                if (!(isTileOccupied.GetValue((int)positionToBeDrawn.X / 32, (int)position.Y / 32)))
                {
                    Tile temp = new Tile(texture.Width, type, positionToBeDrawn);
                    currentTiles.Add(temp);
                    isTileOccupied.SetValue(true,(int)positionToBeDrawn.X / 32, (int)positionToBeDrawn.Y / 32);
                }
                
            }
            else
            {
                PathPoint temp = new PathPoint(position.X, position.Y);
                pathPoints.Add(temp);
            }

        }
   
        static public void SaveMap()
        {
            Map temp = new Map(currentTiles.ToArray(), pathPoints.ToArray());
            XmlReader.TranslateToXmlMap(temp, "TestMap");
        }

        #region Getters

        static public Texture2D SelectedTexture { get { return selectedTexture; } set { selectedTexture = value; } }
        static public Type      SelectedType { get { return selectedType; } set { selectedType = value; } }

        #endregion
    }
}
