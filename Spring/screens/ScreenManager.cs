using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.screens
{
    public sealed class ScreenManager 
    {

        #region Fields

        private GameScreen _currentScreen, _newScreen;

        private Dictionary<string, GameScreen> _screens = new Dictionary<string, GameScreen>();

        private Boolean _inTransition = false;

        #endregion

        #region Methods

        private static ScreenManager _instance;

        public static ScreenManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ScreenManager();
                }
                return _instance;
            }
        }

        public ScreenManager()
        {
            //SwitchScreen("TitleScreen");
            _currentScreen = new TitleScreen("titleScreen", "title");
            _screens.Add("TitleScreen", _currentScreen);
            _screens.Add("GameOverScreen", new TitleScreen("gameOver", "gameOver"));
            _screens.Add("GameWinScreen", new TitleScreen("gameWin"));
        }

        public void LoadContent()
        {
            _currentScreen.LoadContent();
        }

        public void Unload(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            _currentScreen.Update(gameTime);

            if (_inTransition) Transition(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _currentScreen.Draw(gameTime);
        }

        

        public void SwitchScreen(string nextScreen)
        {

            try
            {
                // try to create instance of new screen
                if (!_screens.ContainsKey(nextScreen))
                {
                    _newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Spring.screens." + nextScreen));
                    _screens.Add(nextScreen, _newScreen);
                }
                else
                {
                    _newScreen = _screens[nextScreen];
                }

                _inTransition = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _inTransition = false;
            }
        }

        private void Transition(GameTime gameTime)
        {

            // TODO add transition effect ( fade to black )
            Console.WriteLine("Loading new screen...");
            //_currentScreen.Unload(); Just dont do it, causes way too many issues
            Game1.AudioPlayer.StopSong();
            _currentScreen = _newScreen;
            _newScreen.LoadContent();
            _inTransition = false;
            Console.WriteLine("Loaded new screen!");
        }

        #endregion


    }
}
