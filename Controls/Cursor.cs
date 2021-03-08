using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eden.Controls
{
    public class Cursor : States.State
    {
        Vector2 pos;
        private Texture2D cursorTexture;
        private MouseState currentMouseState;
        
        public Cursor(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            cursorTexture = _content.Load<Texture2D>("Controls/Cursor");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(cursorTexture, pos, Color.White);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            currentMouseState = Mouse.GetState();
            pos = new Vector2(currentMouseState.X, currentMouseState.Y);
        }
    }
}
