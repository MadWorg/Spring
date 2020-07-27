using Microsoft.Xna.Framework;
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

        private bool _hovering;

        private MouseState _previousState, _currentState;

        #endregion

        #region Properties

        public event EventHandler Click;

        public Color TextColor { get; set; }

        public Vector2 Position { get; set; }

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

        public override void Draw(GameTime gameTime)
        {
            var color = Color.White;

            Game1.SpriteBatch.Draw(_texture, Rectangle, Color.White);

            if (_hovering)
            {
                color = Color.Blue;
            }

            
            if(Text != null)
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                Game1.SpriteBatch.DrawString(_font, Text, new Vector2(x, y), color);
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
                }

            }

        }

        #endregion

    }
}
