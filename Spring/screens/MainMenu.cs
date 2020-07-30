using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.ui;

namespace Spring.screens
{
    class MainMenu : GameScreen
    {

        #region Fields

        private Texture2D _background;

        private List<Component> _buttons;

        public string Label = "MainMenu";

        #endregion

        #region Methods

        public MainMenu()
        {
            
        }    

        public override void LoadContent()
        {
            _background = Game1.GameContent.Load<Texture2D>("background/mainMenu");

            _buttons = new List<Component>();

            var playButton = new Button("Play", Game1.GameContent.Load<Texture2D>("interface/button"), Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Text = "Play",
                Position = new Vector2(800, 300)
            };

            playButton.Click += PlayButton_Click;

            var exitButton = new Button("Exit", Game1.GameContent.Load<Texture2D>("interface/button"), Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Text = "Exit",
                Position = new Vector2(800, 550)
            };

            exitButton.Click += ExitButton_Click;

            _buttons.Add(playButton);
            _buttons.Add(exitButton);
             
            // swap gameState to menu

            Game1.GameState = Game1.State.Menu;

        }

        public override void Unload()
        {
            _buttons = null;
            Game1.GameContent.Unload();
        }

        public override void Update(GameTime gameTime)
        {

            if (_buttons.Count == 0) return;

            foreach(Component comp in _buttons)
            {
                comp.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {

            Game1.SpriteBatch.Draw(_background, new Vector2(0,0), Color.White);

            if (_buttons.Count == 0) return;

            foreach (Component comp in _buttons)
            {
                comp.Draw(gameTime);
            }
        }

        //onClick methods for buttons

        private void PlayButton_Click(object sender, System.EventArgs e)
        {
            Console.WriteLine("switching to game");
            ScreenManager.Instance.SwitchScreen("ActionScreen");
            // if saveFile exists, load player from there
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Game1.ExitGame = true;
        }

        #endregion
    }
}
