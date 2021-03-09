using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eden.States
{
    public class GameState : State
    {
        int[,] tileGrid = new int[1000, 1000];
        private Vector2 Screencenter;
        public Vector2 Player { get; set; }
        private Texture2D pskin;
        private Texture2D blocktexture;
        private Camera camera;
        Player _player;
     
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Player.X, (int)Player.Y, blocktexture.Width, blocktexture.Height);
            }
        }
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            pskin = _content.Load<Texture2D>("Player/Player");
            this.camera = new Camera(this._graphicsDevice);
            blocktexture = _content.Load<Texture2D>("Blocks/TILE");
            _player = new Player();
            Screencenter = new Vector2(10, 10);


            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    tileGrid[i, j] = 0;
                }

            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(this.camera);

            for (int i = Math.Max(Mouse.GetState().X - 10, 0); i <= Math.Min(Mouse.GetState().X + 10, 1000); i++)
            {
               for (int j = Math.Max(Mouse.GetState().X - 10, 0); j <= Math.Min(Mouse.GetState().Y+10, 1000); j++) 
                {
                    spriteBatch.Draw(blocktexture, new Rectangle(i, j, blocktexture.Width, blocktexture.Height), new Rectangle(0, 0, blocktexture.Width, blocktexture.Height), Color.White);
                }
            }

            spriteBatch.Draw(pskin, Screencenter, new Rectangle(0, 0, pskin.Width, pskin.Height), Color.White);

            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            Screencenter = new Vector2(_player.playerPos.X, _player.playerPos.X);
            
            this.camera.Update(gameTime);

            this.camera.Position = Screencenter;

        }
    }
}
