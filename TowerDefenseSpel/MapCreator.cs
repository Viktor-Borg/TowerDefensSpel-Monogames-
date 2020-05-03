using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel.MapGeneration
{
    /// <summary>
    /// Responsible for displaying the map the player is currentyl creating aswell as adding and removing new tiles.
    /// </summary>
    static class MapController 
    {
        static private Texture2D                     selectedTexture = UIMapController.GrassTexture;
        static private Type                          selectedType = Type.grass;
        static private List<Tile>                    currentTiles = new List<Tile>();
        static private List<PathPoint>               pathPoints = new List<PathPoint>();
        static private double                        timeDelay = 300;
        static private double                        lastTimeChanaged = 0;
        static private BitArray2D                    isTileOccupied = new BitArray2D(1920/32 + 1,1080/32 + 1);
        static bool                                  removeTileActivated = false;

       // this method checks if the remove mode is active which is activated by pressing the r key it also checks if the user is pressing the left mousebutton and if they are it sends the position of the mouse aswell as the texture and type of the tile and sends this information to the add tile method or reove tile method.
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
                RemoveTile(mouseState.Position.ToVector2(),selectedTexture);
            }

            UIMapController.Drawtiles(currentTiles);

        }

        //in this method the position is first converted to the tile space then it checks if the tile is a pathpoint or not it then checks if the tile position is occupied and if not it adds the tile to the position.
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

        //in this method the position is first converted to tile space then checks so that here is a tile in that position then if there is goes through the current tiles list and remove the corespoonding tile.
        static private void RemoveTile(Vector2 position, Texture2D texture)
        {
            float d = texture.Width;
            float r = d / 2;
            Vector2 positionToBeDrawn = new Vector2((float)(Math.Floor(position.X / d) * d), (float)(Math.Floor(position.Y / d) * d));
            if (isTileOccupied.GetValue((int)positionToBeDrawn.X / 32, (int)positionToBeDrawn.Y / 32))
            {
                foreach(Tile tile in currentTiles)
                {
                    if(tile.X > position.X - 32 && tile.X < position.X + 32 && tile.Y > position.Y - 32 && tile.Y < position.Y + 32)
                    {
                        isTileOccupied.SetValue(false, tile.X / 32, tile.Y / 32);
                        currentTiles.Remove(tile);
                        break;
                    }
                }
            }
        }


       
        // this method is called once the user is done creating the map and calls to translate to xml map method which creates an xml file which describes the map so it can later be loaded back in to the game.
        static public void SaveMap()
        {
            Map temp = new Map(currentTiles.ToArray(), pathPoints.ToArray());
            XmlReader.TranslateToXmlMap(temp, InptController.MapName);
        }

        #region Attributes

        static public Texture2D SelectedTexture { get { return selectedTexture; } set { selectedTexture = value; } }
        static public Type      SelectedType { get { return selectedType; } set { selectedType = value; } }

        #endregion
    }
}
