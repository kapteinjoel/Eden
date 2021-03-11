using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Eden.States;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Eden.Controls;
using Comora;

namespace Eden
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Cursor _cursor;
        private State _currentState;
        private State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.ToggleFullScreen();
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            base.Initialize();
            
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            _cursor = new Cursor(this, graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            _cursor.Update(gameTime);
            _currentState.PostUpdate(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepSkyBlue);
            _currentState.Draw(gameTime, spriteBatch);
            _cursor.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
