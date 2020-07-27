using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.screens
{
    class TitleScreen : GameScreen
    {

        #region Fields

        private Texture2D _texture;

        #endregion
        public TitleScreen() { }

        public override void LoadContent()
        {
            _texture = Game1.GameContent.Load<Texture2D>("background/titleScreen");
        }

        public override void Unload()
        {
            // nothing to do here yet
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Swapping");
                ScreenManager.Instance.SwitchScreen("MainMenu");
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_texture, new Vector2(0, 0), Color.White);
        }

    }
}
