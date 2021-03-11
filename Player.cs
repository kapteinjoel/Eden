using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Eden.States
{
    public class Player : State
    {
        private KeyboardState state;
        Texture2D _skin;

        public Vector2 playerPos;

        public Player(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            
            _skin = content.Load<Texture2D>("Player/Player");
            playerPos = new Vector2(600, 600);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_skin, playerPos, Color.White);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D))
                playerPos.X += 2;
            if (state.IsKeyDown(Keys.A))
                playerPos.X -= 2;
            if (state.IsKeyDown(Keys.W))
                playerPos.Y -= 2;
            if (state.IsKeyDown(Keys.S))
                playerPos.Y += 2;

        }
    }
}
