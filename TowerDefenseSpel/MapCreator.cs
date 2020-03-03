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
        static private double                        timeDelay = 300;
        static private double                        lastTimeChanaged = 0;
        static private BitArray2D                    isTileOccupied = new BitArray2D(1920/32 + 1,1080/32 + 1);
        static bool                                  removeTileActivated = false;

     
        static public void MapCreatorUpdate(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.R) && gameTime.TotalGameTime.TotalMilliseconds > lastTimeChanaged + timeDelay)
            {
                if (removeTileActivated)
                {
                    removeTileActivated = false;
                    lastTimeChanaged = gameTime.TotalGameTime.TotalMilliseconds;
                }
                else
                {
                    removeTileActivated = true;
                    lastTimeChanaged = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }

            if(mouseState.LeftButton == ButtonState.Pressed && !removeTileActivated)
            {

                AddTile(mouseState.Position.ToVector2(), selectedTexture, selectedType);
                
            }
            else if (mouseState.LeftButton == ButtonState.Pressed && removeTileActivated)
            {
                RemoveTile(mouseState.Position.ToVector2());
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

        static private void RemoveTile(Vector2 position)
        {
            float d = 32;
            float r = d / 2;
            Vector2 positionToBeDrawn = new Vector2((float)(Math.Floor(position.X / d) * d), (float)(Math.Floor(position.Y / d) * d));
            if (isTileOccupied.GetValue((int)positionToBeDrawn.X / 32, (int)positionToBeDrawn.Y / 32))
            {
                foreach(Tile tile in currentTiles)
                {
                    if(tile.X > position.X - 16 && tile.X < position.X + 16 && tile.Y > position.Y - 16 && tile.Y < position.Y + 16)
                    {
                        isTileOccupied.SetValue(false, (int)positionToBeDrawn.X / 32, (int)positionToBeDrawn.Y / 32);
                        currentTiles.Remove(tile);
                        break;
                    }
                }
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
