using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Spring.screens
{
    class TitleScreen : GameScreen
    {

        #region Fields

        private Texture2D _texture;

        private string _textureName;

        private string _songName;

        private Song _song;

        private MouseState _previousState, _currentState;

        #endregion

        #region Methods

        public TitleScreen() { }

        public TitleScreen(string background)
        {
            _textureName = background;
        }

        public TitleScreen(string background, string song)
        {
            _textureName = background;
            _songName = song;
        }

        public override void LoadContent()
        {
            _texture = Game1.GameContent.Load<Texture2D>("background/" + _textureName);

            if(_songName != null)
            {
                _song = (Song)Game1.GameContent.Load<Song>("music/" + _songName);
                Game1.AudioPlayer.PlaySong(_song);
            }

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
