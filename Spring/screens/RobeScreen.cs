using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Spring.ui;

namespace Spring.screens
{
    class RobeScreen : GameScreen
    {

        #region Fields

        private Texture2D _background;

        private List<Component> _buttons;

        public string Label = "RobeScreen";

        #endregion

        #region Methods

        public RobeScreen()
        {
            _buttons = new List<Component>();       

        }
        

        public override void LoadContent()
        {

            _background = Game1.GameContent.Load<Texture2D>("background/colorPick");

            var colorOne = new Button("ColorOne", Game1.GameContent.Load<Texture2D>("interface/blank_circle"),
                                                  Game1.GameContent.Load<Texture2D>("spells/spell_border"),
                                                  Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Color = Color.DarkBlue,
                Position = new Vector2(250, 300),
                SoundEffect = Game1.GameContent.Load<SoundEffect>("soundfx/Button_6")
            };

            var colorTwo = new Button("ColorOne", Game1.GameContent.Load<Texture2D>("interface/blank_circle"),
                                                  Game1.GameContent.Load<Texture2D>("spells/spell_border"),
                                                  Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Color = Color.Green,
                Position = new Vector2(540, 300),
                SoundEffect = Game1.GameContent.Load<SoundEffect>("soundfx/Button_6")
            };

            var colorThree = new Button("ColorOne", Game1.GameContent.Load<Texture2D>("interface/blank_circle"),
                                                  Game1.GameContent.Load<Texture2D>("spells/spell_border"),
                                                  Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Color = Color.Yellow,
                Position = new Vector2(250, 600),
                SoundEffect = Game1.GameContent.Load<SoundEffect>("soundfx/Button_6")
            };

            var colorFour = new Button("ColorOne", Game1.GameContent.Load<Texture2D>("interface/blank_circle"),
                                                  Game1.GameContent.Load<Texture2D>("spells/spell_border"),
                                                  Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Color = Color.Purple,
                Position = new Vector2(540, 600),
                SoundEffect = Game1.GameContent.Load<SoundEffect>("soundfx/Button_6")
            };

            var exitButton = new Button("Exit", Game1.GameContent.Load<Texture2D>("interface/exit"),
                                                Game1.GameContent.Load<Texture2D>("spells/spell_border"), 
                                                Game1.GameContent.Load<SpriteFont>("fonts/baseFont"))
            {
                Position = new Vector2(50, 50),
                SoundEffect = Game1.GameContent.Load<SoundEffect>("soundfx/Button_5")
            };

            colorOne.Click += ColorButton_Click;
            colorTwo.Click += ColorButton_Click;
            colorThree.Click += ColorButton_Click;
            colorFour.Click += ColorButton_Click;
            exitButton.Click += ExitButton_Click;

            _buttons.Add(colorOne);
            _buttons.Add(colorTwo);
            _buttons.Add(colorThree);
            _buttons.Add(colorFour);
            _buttons.Add(exitButton);

            Game1.GameState = Game1.State.Menu;
        }

        public override void Unload()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Component comp in _buttons)
            {
                comp.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_background, new Vector2(0, 0), Color.White);

            if (_buttons.Count == 0) return;

            foreach (Component comp in _buttons)
            {
                comp.Draw(gameTime);
            }

            Game1.Player.Draw(gameTime, new Vector2(1050, 130));
        }

        private void ColorButton_Click(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            Game1.Player.Color = button.Color;
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            ScreenManager.Instance.SwitchScreen("MainMenu");
        }

        #endregion
    }
}
