using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders
{

    public class Game1 : Game
    {
        /// <summary>
        /// For game objects
        /// </summary>
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameContent gameContent;
        FontManager fontManager;
        Rectangle mainFrame;
        /// <summary>
        /// Gameplay objects
        /// </summary>
        Player player;
        EnemyWall enemyWall;
        BulletManager bulletManager;
        /// <summary>
        /// State objects
        /// </summary>
        private int _screenWidth = 0;
        private int _screenHeight = 0;
        private MouseState oldMouseState;
        private KeyboardState oldKeyboardState;

        private bool gameStart = false;
        private bool gameEnd = false;
        private int score = 0;

        /// <summary>
        /// Time Objects
        /// </summary>
        private TimeSpan oldGameTime;
        private TimeSpan gamePause;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gamePause = TimeSpan.FromMilliseconds(500);
            oldGameTime = TimeSpan.FromMilliseconds(0);
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
            gameContent = new GameContent(Content);
            

            //Initialize Screen
            _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            if (_screenWidth > 800)
                _screenWidth = 800;
            if (_screenHeight > 600)
                _screenHeight = 600;

            graphics.PreferredBackBufferWidth = _screenWidth;
            graphics.PreferredBackBufferHeight = _screenHeight;
            graphics.ApplyChanges();


            fontManager = new FontManager(_screenWidth, _screenHeight, spriteBatch, gameContent);
            //Initialize gameplay objects
            player = new Player(_screenWidth, _screenHeight, spriteBatch, gameContent);
            enemyWall = new EnemyWall(_screenWidth, _screenHeight, spriteBatch, gameContent);
            bulletManager = new BulletManager(enemyWall, spriteBatch, gameContent);

            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);




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
            //check for game active
            if (!IsActive)
            {
                return;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //trying to keep mouse in gameWindow
            if (Mouse.GetState().X <= 20)
                Mouse.SetPosition(5, Mouse.GetState().Y);
            if (Mouse.GetState().X >= _screenWidth - 20)
                Mouse.SetPosition(_screenWidth - 20, Mouse.GetState().Y);
            if (Mouse.GetState().Y <= 20)
                Mouse.SetPosition(Mouse.GetState().X, 20);
            if (Mouse.GetState().Y >= _screenHeight - 20)
                Mouse.SetPosition(Mouse.GetState().X, _screenHeight - 20);


            KeyboardState newKeyboardState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();

            


            if (oldMouseState.X != newMouseState.X)
            {
                if (newMouseState.X >= 0 || newMouseState.X < _screenWidth)
                {
                    player.MovePlayer(newMouseState.X);
                }
            }

            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed && gameStart)
            {
                bulletManager.Shoot(player.GetX(), player.GetY());
            }
            //center mouse when starting game
            else if(newMouseState.LeftButton == ButtonState.Pressed && !gameStart)
            {
                gameStart = true;
                Mouse.SetPosition(_screenWidth / 2, _screenHeight / 2);
            }
            else if (newMouseState.LeftButton == ButtonState.Pressed && gameEnd)
            {
                this.Exit();
            }

            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                
            }

            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                
            }

            if (oldKeyboardState.IsKeyUp(Keys.Space) && newKeyboardState.IsKeyDown(Keys.Space))
            {
               
            }

            oldMouseState = newMouseState;
            oldKeyboardState = newKeyboardState;

            enemyWall.Update();
            bulletManager.Update();
            if (!enemyWall.GetEnemies().Any(e => e.CheckAlive()))
                gameEnd = true;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {           
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            spriteBatch.Draw(gameContent.imgBackground, mainFrame, Color.White);

            if (gameStart && !gameEnd)
            {                
                player.Draw();
                enemyWall.Draw();
                bulletManager.Draw();
                fontManager.DrawScore(bulletManager.score);

            }
            else if(!gameEnd)
            {
                
                fontManager.DrawTitleScreen();
            }
            else
            {
                fontManager.DrawEndScreen();
            }
            


            spriteBatch.End();

            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
