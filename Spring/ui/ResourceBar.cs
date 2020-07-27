using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spring.ui
{
    public class ResourceBar : Component
    {

        #region Fields

        public string Label;

        private Texture2D _frame;

        private Texture2D _bar;

        private SpriteFont _font;

        #endregion

        #region Properties

        public Color TextColor { get; set; }

        public Color BarColor { get; set; }

        public Vector2 Position { get; set; }

        public int MaxValue { get; set; }

        public int CurValue { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int) Position.X, (int) Position.Y , (int) (_frame.Width * Scale), _frame.Height );
            }
        }

        public float Scale { get; set; }

        public string Text { get; set; }

        #endregion

        #region Methods

        public ResourceBar(Texture2D frame, Texture2D bar, SpriteFont font)
        {
            _frame = frame;
            _bar = bar;
            _font = font;
            TextColor = Color.White;
            Scale = 1.0f;
            BarColor = Color.Magenta; // a bar should no remain this color
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_bar, Rectangle, BarColor);
            Game1.SpriteBatch.Draw(_frame, Rectangle, Color.White);

            if (Text != null)
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                Game1.SpriteBatch.DrawString(_font, Text, new Vector2(x, y), TextColor);
            }   

            
        }

        public override void Update(GameTime gameTime)
        {
            Text = $"{CurValue}/{MaxValue}";
        }

        public void UpdateValues(int maxValue, int curValue)
        {
            MaxValue = maxValue;
            CurValue = curValue;
        }

        #endregion
    }
}
