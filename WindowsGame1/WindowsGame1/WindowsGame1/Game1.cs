using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kbs;
        MouseState ms;
        UInt64 score = 0;
        UInt64 plex = 0;
        Texture2D cursor;
        Texture2D cursor_active;
        Texture2D b_newgame;
        Texture2D b_exit;
        Rectangle rect_newgame;
        Rectangle rect_exit;
        Vector2 cursor_pos;
        enum Scene {MENU, GAME}
        int GameScene = (int)Scene.MENU;
        
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
            cursor = Content.Load<Texture2D>("cursor");
            cursor_active = Content.Load<Texture2D>("cursor_active");
            b_newgame = Content.Load<Texture2D>("button_newgame");
            b_exit = Content.Load<Texture2D>("button_exit");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            
            kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Q)) this.Exit();
            ms = Mouse.GetState();
            cursor_pos.X = ms.X;
            cursor_pos.Y = ms.Y;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (GameScene == (int)Scene.MENU) MenuHandle();
            if (GameScene == (int)Scene.GAME) GameHandle();
            MouseHandle();

            
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        void MenuHandle() 
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(b_newgame, new Rectangle(330, 200, b_newgame.Width, b_newgame.Height), Color.White);
            spriteBatch.Draw(b_exit, new Rectangle(330, 300, b_exit.Width, b_exit.Height), Color.White);
            spriteBatch.End();
        }

        void MouseHandle() 
        {
            rect_exit = new Rectangle(330, 300, b_exit.Width, b_exit.Height);
            rect_newgame = new Rectangle(330, 200, b_newgame.Width, b_newgame.Height);
            spriteBatch.Begin();
            if (GameScene == (int)Scene.MENU)
            {
                if (rect_newgame.Contains((int)cursor_pos.X, (int)cursor_pos.Y) || rect_exit.Contains((int)cursor_pos.X, (int)cursor_pos.Y)) spriteBatch.Draw(cursor_active, cursor_pos, Color.White);
                else spriteBatch.Draw(cursor, cursor_pos, Color.White);
                if (rect_exit.Contains((int)cursor_pos.X, (int)cursor_pos.Y) && (ms.LeftButton == ButtonState.Pressed)) this.Exit();
                if (rect_newgame.Contains((int)cursor_pos.X, (int)cursor_pos.Y) && (ms.LeftButton == ButtonState.Pressed)) GameScene = (int)Scene.GAME;
            }
            if (GameScene == (int)Scene.GAME) spriteBatch.Draw(cursor, cursor_pos, Color.White);
            spriteBatch.End();
        }

        void GameHandle() 
        {
            GraphicsDevice.Clear(Color.Tomato);
        }
    }
}
