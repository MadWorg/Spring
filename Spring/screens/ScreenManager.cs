using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.screens
{
    public class ScreenManager 
    {

        #region Fields

        private Screen _currentScreen, _newScreen;

        private Dictionary<string, Screen> _screens = new Dictionary<string, Screen>();

        private Boolean _inTransition = false;

        #endregion

        #region Methods

        public ScreenManager()
        {
            _currentScreen = new TitleScreen();
            _screens.Add("TitleScreen", _currentScreen);
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
                    _newScreen = (Screen)Activator.CreateInstance(Type.GetType("Spring.screens." + nextScreen));
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
            _currentScreen.Unload();
            _currentScreen = _newScreen;
            _newScreen.LoadContent();
            _inTransition = false;
            Console.WriteLine("Loaded new screen!");
        }

        #endregion


    }
}
