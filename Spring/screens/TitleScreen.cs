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

        private string _textureName = "titleScreen";

        private MouseState _previousState, _currentState;

        #endregion

        #region Methods

        public TitleScreen() { }

        public TitleScreen(string background)
        {
            _textureName = background;
        }

        public override void LoadContent()
        {
            _texture = Game1.GameContent.Load<Texture2D>("background/" + _textureName);

            Game1.GameState = Game1.State.Menu;
        }

        public override void Unload()
        {
            Game1.GameContent.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();

            if (_currentState.LeftButton == ButtonState.Released && _previousState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("Swapping");
                ScreenManager.Instance.SwitchScreen("MainMenu");
            }

        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_texture, new Vector2(0, 0), Color.White);
        }

        #endregion

    }
}
