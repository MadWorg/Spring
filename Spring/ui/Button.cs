using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.ui
{
    class Button : Component
    {

        #region Fields

        public string Label;

        private SpriteFont _font;

        private Texture2D _texture;

        private Texture2D _border;

        private bool _hovering;

        private MouseState _previousState, _currentState;

        #endregion

        #region Properties

        public SoundEffect SoundEffect { get; set; }

        public event EventHandler Click;

        public Color TextColor { get; set; }

        public Vector2 Position { get; set; }

        public Color Color { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - _texture.Width/2, (int)Position.Y - _texture.Height/2, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion


        #region Methods

        public Button(string label, Texture2D texture, SpriteFont font)
        {
            Label = label;
            _texture = texture;
            _font = font;
        }

        public Button(string label, Texture2D texture, Texture2D border, SpriteFont font)
        {
            Label = label;
            _texture = texture;
            _font = font;
            _border = border;
        }

        // add another constructor that can resize the button

        public override void Draw(GameTime gameTime)
        {
            var color = Color.White;
            var borderColor = Color.White;

            if(Color == new Color(0, 0, 0, 0))
            {
                Game1.SpriteBatch.Draw(_texture, Rectangle, Color.White);
            }
            else
            {
                Game1.SpriteBatch.Draw(_texture, Rectangle, Color);
            }

            

            if (_hovering)
            {
                color = Color.Gold;
                borderColor = Color.Red;
            }

            
            if(Text != null)
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                Game1.SpriteBatch.DrawString(_font, Text, new Vector2(x, y), color);
            }

            if(_border != null)
            {
                Game1.SpriteBatch.Draw(_border, Rectangle, borderColor);
            }
            

        }

        public override void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentState.X, _currentState.Y, 1, 1);

            _hovering = false;

            if(mouseRectangle.Intersects(Rectangle))
            {
                _hovering = true;

                if(_currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                    if(SoundEffect != null)
                    {
                        Game1.AudioPlayer.PlaySound(SoundEffect);
                    }                 
                }

            }

        }

        #endregion

    }
}
