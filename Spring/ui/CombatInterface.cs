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

        private Enemy _enemy;

        private bool PlayerTurn = true;

        private ActionScreen _parent;

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

        public CombatInterface(Enemy enemy, ActionScreen parent)
        {

            // get rid of this code ?
            _enemy = enemy;
            _parent = parent;

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
                                           _font, Game1.Player.MaxHealth, Game1.Player.Health)
            {
                Label = "playerHealth",
                BarColor = Color.Red,
                Position = new Vector2(0, 0),
            };

            var playerMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font, Game1.Player.MaxHealth, Game1.Player.Health)
            {
                Label = "playerMana",
                BarColor = Color.Blue,
                Position = new Vector2(0, 55),
                Scale = 0.5f,
            };

            var enemyHealth = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font, _enemy.MaxHealth, _enemy.Health)
            {
                Label = "enemyHealth",
                BarColor = Color.Red,
                Position = new Vector2(1100, 0),
            };

            var enemyMana = new ResourceBar(Game1.GameContent.Load<Texture2D>("interface/uiBar"),
                                           Game1.GameContent.Load<Texture2D>("interface/whiteSquare"),
                                           _font, _enemy.MaxMana, _enemy.Mana)
            {
                Label = "enemyMana",
                BarColor = Color.Blue,
                Position = new Vector2(1350, 55),
                Scale = 0.5f,
            };

            _elements.Add(playerHealth.Label, playerHealth);
            _elements.Add(playerMana.Label, playerMana);

            _elements.Add(enemyHealth.Label, enemyHealth);
            _elements.Add(enemyMana.Label, enemyMana);

            #endregion

            #region Buttons and SpellButtons

            // spell buttons

            var initSpells = Game1.Player.SpellList.GetSpells;

            var SpellOne = new Spellslot("SpellOne", 0)
            {
                Position = new Vector2(200, 774),
                SpellIndex = 0,
                Spell = initSpells[0],
                Parent = _parent
            };

            var SpellTwo = new Spellslot("SpellTwo", 1)
            {
                Position = new Vector2(350, 774),
                SpellIndex = 1,
                Spell = initSpells[1],
                Parent = _parent
            };

            var SpellThree = new Spellslot("SpellThree", 2)
            {
                Position = new Vector2(500, 774),
                SpellIndex = 2,
                Spell = initSpells[2],
                Parent = _parent
            };

            var SpellFour = new Spellslot("SpellFour", 3)
            {
                Position = new Vector2(650, 774),
                SpellIndex = 3,
                Spell = initSpells[3],
                Parent = _parent
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

            var PassButton = new Button("Pass", Game1.GameContent.Load<Texture2D>("interface/exit2"), _font)
            {
                Position = new Vector2(1280, 810)
            };

            ExitButton.Click += ExitButton_Click;

            PassButton.Click += PassButton_Click;

            _elements.Add(ExitButton.Label, ExitButton);
            _elements.Add(PassButton.Label, PassButton);

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


            if(ActionScreen.PlayerTurn)
            {
                foreach (Spellslot slot in _spells)
                {
                    slot.Update(gameTime);
                }
            }


        }

        //updates life and mana bars

        public static void UpdateBar(string barLabel, int maxValue, int curValue)
        {
         
            var bar = (ResourceBar) _elements[barLabel];
            bar.UpdateValue(maxValue, curValue);
            _elements[barLabel] = bar;

        }

        public static void UpdateSpell(Spell[] spells)
        {

            for(int i = 0; i < spells.Length; i++)
            {
                _spells[i].Spell = spells[i]; // finish this, clean up code
            }
            
        }

        // OnClick Methods

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            ScreenManager.Instance.SwitchScreen("MainMenu");
        }

        private void PassButton_Click(object sender, System.EventArgs e)
        {
            ActionScreen.PlayerTurn = false;
        }

        #endregion

    }
}
