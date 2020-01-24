using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefenseSpel.MapGeneration;

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
        Map                   selectedMap;

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
            SceneManager.CurrentState = SceneManager.State.Menu;
            SceneManager.Initialize();
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
            SceneManager.LoadContent(Content, Window);
            UIMapReader.UiMapReaderinitializer(spriteBatch,Window,Content);
            SceneManager.DebugPrint =  new PrintText(Content.Load<SpriteFont>("myFont"));
            textures = new Texture2D[3];
            textures[0] = Content.Load<Texture2D>("grass");
            textures[1] = Content.Load<Texture2D>("water");
            textures[2] = Content.Load<Texture2D>("path");

            


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
           
            switch (SceneManager.CurrentState)
            {
                case SceneManager.State.LevelPicker:
                   // SceneManager.RunUpdate(Content, Window, gameTime);
                    break;
                case SceneManager.State.HighScore:
                    SceneManager.CurrentState = SceneManager.HighScoreUpdate();
                    break;
                case SceneManager.State.Quit:
                    this.Exit();
                    break;
                default:
                    SceneManager.CurrentState = SceneManager.MenuUpdate(gameTime);
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

            switch (SceneManager.CurrentState)
            {
                case SceneManager.State.LevelPicker:
                    UIMapReader.UIMapReaderUpdate(gameTime);

                    break;
                case SceneManager.State.HighScore:
                    selectedMap = XmlReader.LoadMapScene("TestMap");
                    selectedMap.DrawMap(spriteBatch, textures);

                    break;
                case SceneManager.State.Quit:
                    this.Exit();
                    break;
                default:
                    SceneManager.MenuDraw(spriteBatch);
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
