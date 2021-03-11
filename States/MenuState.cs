using Eden.Eden.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Eden.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        Texture2D menuback;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            menuback = _content.Load<Texture2D>("Controls/EdenTitle");
            var buttonTexture = _content.Load<Texture2D>("Controls/SINGLEPLAYER");

            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var buttonSound = _content.Load<SoundEffect>("Sounds/ButtonHover2");

            var buttonClick = _content.Load<SoundEffect>("Sounds/YesClick");

            var SinglePlayerButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width*46/100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height*7/16),
                Text = "",
            };

            SinglePlayerButton.Click += SingleGameButton_Click;

            buttonTexture = _content.Load<Texture2D>("Controls/MULTIPLAYER");

            var MultiGameButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width*93/200,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height*9/16),
                Text = "",
            };

            MultiGameButton.Click += MultiGameButton_Click;

            buttonClick = _content.Load<SoundEffect>("Sounds/NopeClick");

            buttonTexture = _content.Load<Texture2D>("Controls/QUITGAME");

            var quitGameButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width*94/200, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height*11/16),
                Text = "",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                SinglePlayerButton,
                MultiGameButton,
                quitGameButton,
            };
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(225);
            _game.Exit();
        }

        private void MultiGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void SingleGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new PlayerLoader(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(menuback, Vector2.Zero, Color.White);

            foreach (var component in _components) 
            {
            component.Draw(gameTime, spriteBatch);
            }



            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
