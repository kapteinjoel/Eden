using System;
using System.Collections.Generic;
using System.Text;

namespace Eden
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Eden.Controls
    {
        public class Button : Component
        {
            #region Fields

            private SoundEffect _sound;
            private SoundEffect _click;
            private MouseState _currentMouse;
            private MouseState _previousMouse;
            private SpriteFont _font;
            private bool _isHovering;
            private bool playsound;
            private Texture2D _texture;

            

            #endregion

            #region Properties

            public event EventHandler Click;

            public bool Clicked { get; private set; }

            public Color PenColour { get; set; }

            public Vector2 Position { get; set; }

            public Rectangle Rectangle
            {
                get
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
                }
            }

            public string Text { get; set; }

            #endregion

            #region Methods

            public Button(Texture2D texture, SpriteFont font, SoundEffect sound , SoundEffect click)
            {

                _texture = texture;

                _font = font;

                _sound = sound;

                _click = click;

                PenColour = Color.Black;
            }

            public void LoadContent(ContentManager content)
            {
                
            }

            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {

                if (_isHovering)
                {
                    
                    spriteBatch.Draw(_texture, new Rectangle((int)Position.X-2, (int)Position.Y-2, _texture.Width + 4, _texture.Height + 4), new Rectangle(0, 0, _texture.Width, _texture.Height), Color.MonoGameOrange);
                }
                else
                {
                    spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height), new Rectangle(0, 0, _texture.Width, _texture.Height), Color.White);
                }
                

                if (!string.IsNullOrEmpty(Text))
                {
                    var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                    var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                    spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
                }
            }

            public override void Update(GameTime gameTime)
            {
                _previousMouse = _currentMouse;
                _currentMouse = Mouse.GetState();

                var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

                _isHovering = false;

                if (mouseRectangle.Intersects(Rectangle))
                {
                    _isHovering = true;
                    if (playsound)
                    {
                        _sound.Play();
                        playsound = false;
                    }
                    

                    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        _click.Play();
                        Click?.Invoke(this, new EventArgs());
                    }
                }
                else
                {
                    playsound = true;
                }
            }

            #endregion
        }
    }
}
