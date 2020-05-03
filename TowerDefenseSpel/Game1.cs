using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TowerDefenseSpel.MapGeneration;
using TowerDefenseSpel.GamePlay;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseSpel
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class Game1 : Game
    {
      private GraphicsDeviceManager graphics;
      private SpriteBatch           spriteBatch;
      private Texture2D[]           textures;
      private Texture2D[]           enemyTextures;
      private Texture2D[]           towerTextures;
      private Texture2D             projectileTexture;
      private static Map            selectedMap;
      private static bool                  hasBeenCalledd = false;
      private static bool                  nameChosen = false;
      private string[]              mapNames;
      private static  InteractableMenu      interactableMenu;
      private static bool           mapHasBeenSelected = false;
        private TextPage tileHelpMenu;
        private TextPage gameHelpMenu;
        private bool helpMenuActive = true;
        private int delay = 500;
        private double previouslyActiveMenuTime = 0;

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
            PlayerController.Font = Content.Load<SpriteFont>("myFont");
            InptController.initialize(PlayerController.Font);
            textures = new Texture2D[3];
            textures[0] = Content.Load<Texture2D>("grass");
            textures[1] = Content.Load<Texture2D>("water");
            textures[2] = Content.Load<Texture2D>("path");
            towerTextures = new Texture2D[1];
            towerTextures[0] = Content.Load<Texture2D>("Enemy");
            projectileTexture = towerTextures[0];
            enemyTextures = new Texture2D[1];
            enemyTextures[0] = Content.Load<Texture2D>("Enemy");
            mapNames = XmlReader.GetNames();
            interactableMenu = new InteractableMenu(mapNames, Content.Load<SpriteFont>("myFont"));
            tileHelpMenu = XmlReader.GetHelpMenu(spriteBatch, PlayerController.Font, "TileHelpMenu");
            gameHelpMenu = XmlReader.GetHelpMenu(spriteBatch, PlayerController.Font, "GameHelpMenu");

            
            
            

            


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
                    KeyboardState keyboardState = Keyboard.GetState();
                    if (!nameChosen && !helpMenuActive)
                    {
                        nameChosen = InptController.InputUpdate(gameTime);
                        
                        
                    }
                    if (!helpMenuActive)
                    {
                        if (gameTime.TotalGameTime.TotalMilliseconds > delay + previouslyActiveMenuTime && keyboardState.IsKeyDown(Keys.H))
                        {
                            helpMenuActive = true;
                            previouslyActiveMenuTime = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                    }
                    else if (helpMenuActive)
                    {
                        if (keyboardState.IsKeyDown(Keys.H) && gameTime.TotalGameTime.TotalMilliseconds > delay + previouslyActiveMenuTime)
                        {
                            helpMenuActive = false;
                            previouslyActiveMenuTime = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                    }
                   // SceneManager.RunUpdate(Content, Window, gameTime);
                    break;
                case SceneController.State.HighScore:
                    KeyboardState keyboardState1 = Keyboard.GetState();
                    if (mapHasBeenSelected && !helpMenuActive)
                    {
                        selectedMap.MapUpdate();
                    }
                    if (!helpMenuActive)
                    {
                        if (gameTime.TotalGameTime.TotalMilliseconds > delay + previouslyActiveMenuTime && keyboardState1.IsKeyDown(Keys.H))
                        {
                            helpMenuActive = true;
                            previouslyActiveMenuTime = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                    }
                    else if (helpMenuActive)
                    {
                        if (keyboardState1.IsKeyDown(Keys.H) && gameTime.TotalGameTime.TotalMilliseconds > delay + previouslyActiveMenuTime)
                        {
                            helpMenuActive = false;
                            previouslyActiveMenuTime = gameTime.TotalGameTime.TotalMilliseconds;
                        }
                    }
                    UITowerController.Update();
                   
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
                    if (nameChosen && !helpMenuActive)
                    {
                        UIMapController.UIMapReaderUpdate(gameTime);
                    }
                    else if(!helpMenuActive)
                    {
                        InptController.MapUDrawpdate(spriteBatch);
                    }

                    if (helpMenuActive)
                    {
                        tileHelpMenu.Draw(spriteBatch);
                    }
                  

                    break;
                case SceneController.State.HighScore:
                    if (mapHasBeenSelected && !helpMenuActive)
                    {
                        selectedMap.DrawMap(spriteBatch, textures);
                        if (!hasBeenCalledd)
                        {
                            
                            WaveController.Initilazie(selectedMap.PathPoints, enemyTextures);
                            PlayerController.Initalize(spriteBatch);
                            UITowerController.Initilalize(towerTextures,projectileTexture);
                            hasBeenCalledd = true;
                        }
                        WaveController.Update(spriteBatch);
                        PlayerController.draw(spriteBatch);
                        TowerController.Update(gameTime, spriteBatch);
                    }
                    else if(!helpMenuActive)
                    {
                        interactableMenu.Draw(spriteBatch);
                    }

                    if (helpMenuActive)
                    {
                        gameHelpMenu.Draw(spriteBatch);
                    }
                  
                  
                   
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

        #region Attributes

        public static Map Map { set { selectedMap = value; } }
        public static bool MapHasBeenSelected { set { mapHasBeenSelected = value; } }
        public static bool NameChosen { set { nameChosen = value; } }

        public static bool HasBeenCalled { get { return hasBeenCalledd; } set { hasBeenCalledd = value; } }

        public static InteractableMenu InteractableMenu { get { return interactableMenu; } }

        #endregion



    }
}
