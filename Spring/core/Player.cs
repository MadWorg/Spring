using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spring.ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.core
{
    public class Player : Entity
    {
        private Texture2D _sprite;

        #region Properties

        public new int Health
        {
            get { return _hp; }

            set
            {
                _hp = value;
                UpdateUI("playerHealth", "hp");
            }
        }

        public new int MaxHealth
        {
            get { return _maxHp; }

            set
            {
                _maxHp = value;
                UpdateUI("playerHealth", "hp");
            }
        }

        public new int Mana
        {
            get { return _mana; }

            set
            {
                _mana = value;
                UpdateUI("playerMana", "mana");
            }
        }

        public new int MaxMana
        {
            get { return _maxMana; }

            set
            {
                _maxMana = value;
                UpdateUI("playerMana", "mana");
            }
        }

        #endregion

        #region Methods

        public Player()
        {
            Health = MaxHealth = 25;
            Mana = MaxMana = 3;
            Spells = new Spellbook();
        }

        public Player(int hp, int mana)
        {
            Health = MaxHealth = hp;
            Mana = MaxMana = mana;
            Spells = new Spellbook();
        }

        public void LoadContent()
        {
            //_sprite = Game1.GameContent.Load<Texture2D>("interface/whiteSquare");
            _sprite = Game1.GameContent.Load<Texture2D>("entity/player");
        }

        public void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(_sprite, new Rectangle(230, 120, 350, 630), Color.White);
        }

        public void UpdateUI(string label, string barType)
        {

            if(Game1.GameState != Game1.State.Playing)
            {
                return;
            }

            if(barType == "hp")
            {
                CombatInterface.UpdateBar(label, _maxHp, _hp);
            }
            else if(barType == "mana")
            {
                CombatInterface.UpdateBar(label, _maxMana, _mana);
            }

            // might add xp bar
        }

        #endregion


    }
}
