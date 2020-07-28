using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.ui
{
    public class CombatInterface
    {

        #region Fields

        private Texture2D _spellBar;

        private Texture2D _resourceBar;

        private Texture2D _hpBar;

        private Texture2D _manaBar;

        private SpriteFont _font;

        //testing variables

        private Texture2D spell;
        private Texture2D border;

        public static Dictionary<string, Component> elements = new Dictionary<string, Component>();

        #endregion

        #region Properties

        public static int PlayerMaxHealth { get; set; }
        public static int PlayerCurHealth { get; set; }

        public static int PlayerMaxMana { get; set; }
        public static int PlayerCurMana { get; set; }

        public static int EnemyMaxHealth { get; set; }
        public static int EnemyCurHealth { get; set; }

        public static int EnemyMaxMana { get; set; }
        public static int EnemyCurMana { get; set; }

        #endregion

        #region Methods

        public CombatInterface()
        {
            PlayerMaxHealth = PlayerCurHealth = 100;
            PlayerMaxMana = PlayerCurMana = 3;

            EnemyMaxHealth = EnemyCurHealth = 100;
            EnemyMaxHealth = EnemyCurMana = 3;
        }

        public void LoadContent()
        {
            _spellBar = Game1.GameContent.Load<Texture2D>("interface/spellBar");
            _font = Game1.GameContent.Load<SpriteFont>("fonts/baseFont");

            spell = Game1.GameContent.Load<Texture2D>("spells/fireball_icon");
            border = Game1.GameContent.Load<Texture2D>("spells/spell_border");

            #region Life and Mana bars

            var playerHealth = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "playerHealth",
                BarColor = Color.Red,
                Position = new Vector2(0, 0),
                MaxValue = 100,
                CurValue = 100
            };

            var playerMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "playerMana",
                BarColor = Color.Blue,
                Position = new Vector2(0, 55),
                Scale = 0.5f
            };

            var enemyHealth = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "enemyHealth",
                BarColor = Color.Red,
                Position = new Vector2(1100, 0),
            };

            var enemyMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "enemyMana",
                BarColor = Color.Blue,
                Position = new Vector2(1350, 55),
                Scale = 0.5f
            };

            elements.Add(playerHealth.Label, playerHealth);
            elements.Add(playerMana.Label, playerMana);

            elements.Add(enemyHealth.Label, enemyHealth);
            elements.Add(enemyMana.Label, enemyMana);

            #endregion

            #region Buttons

            var SpellOne = new Spellslot("SpellOne")
            {
                Position = new Vector2(200, 774),
            };

            var SpellTwo = new Spellslot("SpellTwo")
            {
                Position = new Vector2(350, 774),
            };

            var SpellThree = new Spellslot("SpellThree")
            {
                Position = new Vector2(500, 774),
            };

            var SpellFour = new Spellslot("SpellFour")
            {
                Position = new Vector2(650, 774),
            };

            elements.Add(SpellOne.Label, SpellOne);
            elements.Add(SpellTwo.Label, SpellTwo);
            elements.Add(SpellThree.Label, SpellThree);
            elements.Add(SpellFour.Label, SpellFour);

            var ExitButton = new Button("Exit", Game1.GameContent.Load<Texture2D>("interface/exit2"), _font)
            {
                Position = new Vector2(1380, 810)
            };

            ExitButton.Click += ExitButton_Click;

            elements.Add(ExitButton.Label, ExitButton);

            #endregion

        }

        public void Draw(GameTime gameTime)
        {

            
            Game1.SpriteBatch.Draw(_spellBar, new Vector2(0, 900 - _spellBar.Height), Color.White);


            foreach(KeyValuePair<string, Component> entry in elements)
            {
                entry.Value.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Component> entry in elements)
            {
                entry.Value.Update(gameTime);
            }
        }

        //updates life and mana bars

        public static void UpdateBar(string barLabel, int maxValue, int curValue)
        {
            Console.WriteLine(barLabel);

            foreach(KeyValuePair<string, Component> entry in elements)
            {
                Console.WriteLine(entry.Key);
            }

            var bar = (ResourceBar) elements[barLabel];
            bar.UpdateValues(maxValue, curValue);
        }

        // method for exit button

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            ScreenManager.Instance.SwitchScreen("MainMenu");
        }

        #endregion

    }
}
