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
        private KeyboardState state;
        private int x;
        private int y;
        private int startCol;
        private int endCol;
        private int startRow;
        private int endRow;
        private int offsetX;
        private int offsetY;
        Random rnd;
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
            rnd = new Random();
            _player = new Player(game, graphicsDevice, content);
            this.camera = new Camera(this._graphicsDevice);
            blocktexture = _content.Load<Texture2D>("Blocks/TILE");
            Screencenter = new Vector2(10, 10);

            //populate world start
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    tileGrid[i, j] = 1;
                    
                }

            }
            //populate world end

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(this.camera);
            //draw tile start
            for(int c = startCol; c <= endCol; c++)
            {
                for (int r = startRow; r <= endRow; r++)
                {
                    x = (c - startCol) * 17;
                    y = (r - startRow) * 17;
                    Vector2 pxy = new Vector2(x, y);
                    spriteBatch.Draw(blocktexture, pxy, Color.White);
                }
            }
            //draw tile end
            
            // player start
            _player.Draw(gameTime,spriteBatch);
            //player end
    
            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            state = Keyboard.GetState();
            
            //render start calc
            startCol = (int)Math.Floor(this.camera.Position.X / 17);
            endCol = startCol + (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 17);
            startRow = (int)Math.Floor(this.camera.Position.Y / 17);
            endRow = startRow + (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 17);
            offsetX = (int)(-this.camera.Position.X + startCol * 17);
            offsetY = (int)(-this.camera.Position.Y + startRow * 17);
            //render end calc

            //player start
            _player.Update(gameTime);
            Screencenter = new Vector2(_player.playerPos.X, _player.playerPos.Y);
            //player end

            //camera start
            this.camera.Update(gameTime);
            this.camera.Position = Screencenter;
            //camera end

        }
    }
}
