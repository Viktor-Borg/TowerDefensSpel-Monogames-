using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseSpel.MapGeneration;
using TowerDefenseSpel.GamePlay;

namespace TowerDefenseSpel
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch           spriteBatch;
        Texture2D[]           textures;
        Texture2D[]           enemyTextures;
        Map                   selectedMap;
        bool                  hasBeenCalledd = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ToggleFullScreen();
            IsMouseVisible = true;
            graphics.ApplyChanges();
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic
            SceneController.CurrentState = SceneController.State.Menu;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SceneController.LoadContent(Content, Window);
            UIMapController.UiMapReaderinitializer(spriteBatch,Window,Content);
            SceneController.DebugPrint =  new PrintText(Content.Load<SpriteFont>("myFont"));
            PlayerController.Font = Content.Load<SpriteFont>("myFont");
            textures = new Texture2D[3];
            textures[0] = Content.Load<Texture2D>("grass");
            textures[1] = Content.Load<Texture2D>("water");
            textures[2] = Content.Load<Texture2D>("path");
            enemyTextures = new Texture2D[1];
            enemyTextures[0] = Content.Load<Texture2D>("Enemy");
            
            

            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            switch (SceneController.CurrentState)
            {
                case SceneController.State.LevelPicker:
                   // SceneManager.RunUpdate(Content, Window, gameTime);
                    break;
                case SceneController.State.HighScore:
                    SceneController.CurrentState = SceneController.HighScoreUpdate();
                   
                    break;
                case SceneController.State.Quit:
                    this.Exit();
                    break;
                default:
                    SceneController.CurrentState = SceneController.MenuUpdate(gameTime);
                    break;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            switch (SceneController.CurrentState)
            {
                case SceneController.State.LevelPicker:
                    UIMapController.UIMapReaderUpdate(gameTime);

                    break;
                case SceneController.State.HighScore:
                    selectedMap = XmlReader.LoadMapScene("TestMap");
                    selectedMap.DrawMap(spriteBatch, textures);
                    if (hasBeenCalledd)
                    {
                        WaveController.Initilazie(selectedMap.PathPoints, enemyTextures);
                        PlayerController.Initalize(spriteBatch);
                        hasBeenCalledd = false;
                    }
                    WaveController.Update(spriteBatch);
                    PlayerController.draw(spriteBatch);
                   
                    break;
                case SceneController.State.Quit:
                    this.Exit();
                    break;
                default:
                    SceneController.MenuDraw(spriteBatch);
                    break;
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #region helperMethods

      

        #endregion
    }
}
