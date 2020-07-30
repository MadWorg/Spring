using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.core;
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

        private SpriteFont _font;

        //testing variables

        public static Dictionary<string, Component> _elements;

        private static Spellslot[] _spells;

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

            // get rid of this code !!!
           
            PlayerMaxHealth = Game1.Player.MaxHealth;
            PlayerCurHealth = Game1.Player.Health;

            PlayerMaxMana = Game1.Player.MaxMana;
            PlayerCurMana = Game1.Player.Mana;

            EnemyMaxHealth = EnemyCurHealth = 100;
            EnemyMaxMana = EnemyCurMana = 3;
        }

        public void LoadContent()
        {
            _spellBar = Game1.GameContent.Load<Texture2D>("interface/spellBar");
            _font = Game1.GameContent.Load<SpriteFont>("fonts/baseFont");

            _elements = new Dictionary<string, Component>(); // make dictionary for ui components
            _spells = new Spellslot[4];

            #region Life and Mana bars

            var playerHealth = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "playerHealth",
                BarColor = Color.Red,
                Position = new Vector2(0, 0),
                MaxValue = PlayerMaxHealth,
                CurValue = PlayerCurHealth
            };

            var playerMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "playerMana",
                BarColor = Color.Blue,
                Position = new Vector2(0, 55),
                Scale = 0.5f,
                MaxValue = PlayerMaxMana,
                CurValue = PlayerCurMana
            };

            var enemyHealth = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "enemyHealth",
                BarColor = Color.Red,
                Position = new Vector2(1100, 0),
                MaxValue = EnemyMaxHealth,
                CurValue = EnemyCurHealth
            };

            var enemyMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font)
            {
                Label = "enemyMana",
                BarColor = Color.Blue,
                Position = new Vector2(1350, 55),
                Scale = 0.5f,
                MaxValue = EnemyMaxMana,
                CurValue = EnemyCurMana
            };

            _elements.Add(playerHealth.Label, playerHealth);
            _elements.Add(playerMana.Label, playerMana);

            _elements.Add(enemyHealth.Label, enemyHealth);
            _elements.Add(enemyMana.Label, enemyMana);

            #endregion

            #region Buttons and SpellButtons

            // spell buttons

            var SpellOne = new Spellslot("SpellOne", 0)
            {
                Position = new Vector2(200, 774),
                SpellIndex = 0
            };

            var SpellTwo = new Spellslot("SpellTwo", 1)
            {
                Position = new Vector2(350, 774),
                SpellIndex = 1
            };

            var SpellThree = new Spellslot("SpellThree", 2)
            {
                Position = new Vector2(500, 774),
                SpellIndex = 2
            };

            var SpellFour = new Spellslot("SpellFour", 3)
            {
                Position = new Vector2(650, 774),
                SpellIndex = 3
            };

            _spells[0] = SpellOne;
            _spells[1] = SpellTwo;
            _spells[2] = SpellThree;
            _spells[3] = SpellFour;


            // regular buttons

            var ExitButton = new Button("Exit", Game1.GameContent.Load<Texture2D>("interface/exit2"), _font)
            {
                Position = new Vector2(1380, 810)
            };

            ExitButton.Click += ExitButton_Click;

            _elements.Add(ExitButton.Label, ExitButton);

            #endregion

        }

        public void Draw(GameTime gameTime)
        {

            
            Game1.SpriteBatch.Draw(_spellBar, new Vector2(0, 900 - _spellBar.Height), Color.White);


            foreach(KeyValuePair<string, Component> entry in _elements)
            {
                entry.Value.Draw(gameTime);
            }

            foreach (Spellslot slot in _spells)
            {
                slot.Draw(gameTime);
            }

        }

        public void Update(GameTime gameTime)
        {

            foreach (KeyValuePair<string, Component> entry in _elements)
            {
                entry.Value.Update(gameTime);
            }

            foreach (Spellslot slot in _spells)
            {
                slot.Update(gameTime);
            }

        }

        //updates life and mana bars

        public static void UpdateBar(string barLabel, int maxValue, int curValue)
        {
            foreach(KeyValuePair<string, Component> entry in _elements)
            {
                Console.WriteLine(entry.Key);
            }

            var bar = (ResourceBar) _elements[barLabel];
            bar.UpdateValues(maxValue, curValue);
        }

        public static void UpdateSpell(Spell[] newSpells)
        {

            for(int i = 0; i < newSpells.Length; i++)
            {
                _spells[i].Spell = newSpells[i]; // finish this, clean up code
            }
            
        }

        // method for exit button

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            ScreenManager.Instance.SwitchScreen("MainMenu");
        }

        #endregion

    }
}
