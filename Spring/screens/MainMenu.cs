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
    class MainMenu : Screen
    {

        private Texture2D _background;

        private List<Component> _buttons;

        public MainMenu()
        {
            _buttons = new List<Component>();
        }    

        public override void LoadContent()
        {
            _background = Game1.GameContent.Load<Texture2D>("background/mainMenu");

            var playButton = new Button("Play", Game1.GameContent.Load<Texture2D>("interface/button"), Game1.GameContent.Load<SpriteFont>("fonts/baseFont"), new Vector2(800, 300))
            {
                Text = "Play",
            };

            playButton.Click += PlayButton_Click;

            var exitButton = new Button("Exit", Game1.GameContent.Load<Texture2D>("interface/button"), Game1.GameContent.Load<SpriteFont>("fonts/baseFont"), new Vector2(800, 550))
            {
                Text = "Exit",
            };

            exitButton.Click += ExitButton_Click;

            _buttons.Add(playButton);
            _buttons.Add(exitButton);
        }

        public override void Unload()
        {
            Console.WriteLine("No unloading yet");
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

        private void PlayButton_Click(object sender, System.EventArgs e)
        {
            Console.WriteLine("switching to game");
            //Game1.ScreenManager.SwitchScreen("GameScreen");
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Game1.ExitGame = true;
        }
    }
}
