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
    public class PlayerLoader : State
    {
        private List<Component> _components;
        public PlayerLoader(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            var MenuBack = _content.Load<Texture2D>("Controls/MenuBack");
            var buttonSound = _content.Load<SoundEffect>("Sounds/ButtonHover2");
            var buttonClick = _content.Load<SoundEffect>("Sounds/YesClick");
            var newGameButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 3 / 36, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 4 / 5),
                Text = "Test",
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 15 / 36, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 4 / 5),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            buttonClick = _content.Load<SoundEffect>("Sounds/NopeClick");

            var backGameButton = new Button(buttonTexture, buttonFont, buttonSound, buttonClick)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 7 / 36, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 4 / 5),
                Text = "Back",
            };

            backGameButton.Click += BackGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                backGameButton,
            };
        }

        private void BackGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            //_game.ChangeState(new CharacterMenu(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);


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
